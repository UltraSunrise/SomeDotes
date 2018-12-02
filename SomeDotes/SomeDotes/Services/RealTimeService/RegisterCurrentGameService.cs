using System;
using SomeDotes.Data.Entities;
using SomeDotes.Models.Intefaces;
using SomeDotes.Services.DatabaseServices;

namespace SomeDotes.Services.RealTimeService
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Win32;
    using SomeDotes.Data;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.JSONModels.RealtimeGameModels;
    using SomeDotes.Models.MainModels;
    using SomeDotes.Services.Helpers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class RegisterCurrentGameService : IRegisterCurrentGameService
    {
        #region Declaration

        private ICurrentGameService cgs;
        private IConvertSteamIdToAccountId converter;
        private IDatabaseService dbService;
        private bool isNewGame;
        private readonly string PRIVATE_ACCOUNT = "4294967295";
        private MatchInfo currentMatchInfo;
        private static RegisterCurrentGameService singelton;

        #endregion

        #region Initialize

        private RegisterCurrentGameService()
        {
            dbService = new DatabaseService();
            converter = new ConvertSteamIdToAccountId();
            isNewGame = true;
        }

        #endregion

        #region Public Methods

        public MatchInfo CurrentMatchInfo
        {
            get
            {
                if (currentMatchInfo == null)
                    currentMatchInfo = new MatchInfo();
                return currentMatchInfo;
            }
            set
            {
                if (value == null)
                    return;
                currentMatchInfo = value;
            }
        }

        public void Run()
        {
            RegisterCGSFile();

            Process[] programName = Process.GetProcessesByName("Dota2");
            if (programName.Length != 0)
            {
                cgs = new CurrentGameService(4000);
                cgs.NewGameState += OnNewGameState;

                cgs.Start();
            }
        }

        public MatchInfo MatchInfo()
        {
            return CurrentMatchInfo;
        }

        #endregion

        #region Private Methods

        private void OnNewGameState(CurrentGameStateService gs)
        {
            RootObject ro = gs.ParsedData;

            var steamIds = FindAllSteamIds(gs.ParsedData);
            MatchInfo matchInfo = new MatchInfo();

            matchInfo.MatchID = gs.ParsedData.Map.MatchId;
            matchInfo.RadiantGold = gs.ParsedData.MainPlayer.RadiantTeam.Player0.NetWorth;
            matchInfo.DireGold = gs.ParsedData.MainPlayer.DireTeam.Player5.NetWorth;
            matchInfo.WinProbability = gs.ParsedData.Map.RadiantWinChance;
            matchInfo.RadiantKills = gs.ParsedData.MainPlayer.RadiantTeam.GetAllPlayers.Sum(p => p.Kills);
            matchInfo.DireKills = gs.ParsedData.MainPlayer.DireTeam.GetAllPlayers.Sum(p => p.Kills);
            TimeSpan t = TimeSpan.FromSeconds(gs.ParsedData.Map.ClockTime);
            matchInfo.MatchTime = string.Format("{0:D2}:{1:D2}",
                                            t.Minutes,
                                            t.Seconds);

            //All players
            matchInfo.RadiantTeam = gs.ParsedData.MainPlayer.RadiantTeam.GetAllPlayers;
            matchInfo.DireTeam = gs.ParsedData.MainPlayer.DireTeam.GetAllPlayers;
            //All players current networth
            matchInfo.HeroesNetWorth.AddRange(gs.ParsedData.MainPlayer.RadiantTeam.GetAllPlayers.Select(gap => gap.NetWorth));
            matchInfo.HeroesNetWorth.AddRange(gs.ParsedData.MainPlayer.DireTeam.GetAllPlayers.Select(gap => gap.NetWorth));
            //All players current gold
            matchInfo.HeroesCurrentGold.AddRange(gs.ParsedData.MainPlayer.RadiantTeam.GetAllPlayers.Select(gap => gap.Gold));
            matchInfo.HeroesCurrentGold.AddRange(gs.ParsedData.MainPlayer.DireTeam.GetAllPlayers.Select(gap => gap.Gold));
            //All players reliable gold
            matchInfo.HeroesReliableGold.AddRange(gs.ParsedData.MainPlayer.RadiantTeam.GetAllPlayers.Select(gap => gap.GoldReliable));
            matchInfo.HeroesReliableGold.AddRange(gs.ParsedData.MainPlayer.DireTeam.GetAllPlayers.Select(gap => gap.GoldReliable));
            //All players buybackcost
            matchInfo.HeroesBuybackCost.AddRange(gs.ParsedData.Hero.RadiantTeam.AllPlayers.Select(p => p.BuybackCost));
            matchInfo.HeroesBuybackCost.AddRange(gs.ParsedData.Hero.DireTeam.AllPlayers.Select(p => p.BuybackCost));
            //All players buyback cooldown
            matchInfo.HeroesBuybackCooldown.AddRange(gs.ParsedData.Hero.RadiantTeam.AllPlayers.Select(p => p.BuybackCooldown));
            matchInfo.HeroesBuybackCooldown.AddRange(gs.ParsedData.Hero.DireTeam.AllPlayers.Select(p => p.BuybackCooldown));
            
            LoadImages(matchInfo, gs);

            CurrentMatchInfo = matchInfo;

            isNewGame = false;
        }

        private List<string> FindAllSteamIds(RootObject parsedData)
        {
            List<string> allSteamIds = new List<string>();

            allSteamIds.AddRange(parsedData.MainPlayer.RadiantTeam.GetAllPlayers.Select(p => p.SteamId));
            allSteamIds.AddRange(parsedData.MainPlayer.DireTeam.GetAllPlayers.Select(p => p.SteamId));

            return allSteamIds.Where(asi => asi != PRIVATE_ACCOUNT).ToList();
        }

        private HeroDb GetHero(long id)
        {
            var currentHero = dbService.GetAllHeroes().FirstOrDefault(h => h.HeroId == id);

            return currentHero;
        }

        private void LoadImages(MatchInfo matchInfo, CurrentGameStateService gs)
        {
            ImagesHelper imagesHelper = ImagesHelper.GetInstance();

            if (!imagesHelper.AreAllAdded)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (imagesHelper.AllImages[i] == null)
                    {
                        imagesHelper.AllImages[i] = ConvertByteArrayToString(GetHero(gs.ParsedData.Hero.AllHeroes[i].Id));
                    }
                    if (imagesHelper.AllImages.Where(ai => ai != null).Count() == 10)
                        imagesHelper.AreAllAdded = true;
                }
            }
            matchInfo.HeroesImages = imagesHelper.AllImages;
        }

        private string ConvertByteArrayToString(HeroDb hero)
        {
            return string.Format("data:image/png;base64,{0}",
                Convert.ToBase64String(hero?.ImageFull));
        }

        #region RegisterGame

        private void RegisterCGSFile()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");

            if (regKey != null)
            {
                string gsifolder = regKey.GetValue("SteamPath") +
                                   @"\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration";
                Directory.CreateDirectory(gsifolder);
                string gsifile = gsifolder + @"\gamestate_integration_testGSI.cfg";
                if (File.Exists(gsifile))
                    return;

                string[] contentofgsifile =
                {
                    "\"Dota 2 Integration Configuration\"",
                    "{",
                    "    \"uri\"           \"http://localhost:4000\"",
                    "    \"timeout\"       \"5.0\"",
                    "    \"buffer\"        \"0.1\"",
                    "    \"throttle\"      \"0.1\"",
                    "    \"heartbeat\"     \"30.0\"",
                    "    \"data\"",
                    "    {",
                    "        \"provider\"      \"1\"",
                    "        \"map\"           \"1\"",
                    "        \"player\"        \"1\"",
                    "        \"hero\"          \"1\"",
                    "        \"abilities\"     \"1\"",
                    "        \"items\"         \"1\"",
                    "    }",
                    "}",

                };

                File.WriteAllLines(gsifile, contentofgsifile);
            }
        }

        public static RegisterCurrentGameService GetInstance()
        {
            return singelton ?? (singelton = new RegisterCurrentGameService());
        }

        #endregion

        #endregion
    }
}
