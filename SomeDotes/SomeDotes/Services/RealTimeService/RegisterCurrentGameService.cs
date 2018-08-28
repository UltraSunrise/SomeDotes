namespace SomeDotes.Services.RealTimeService
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Win32;
    using SomeDotes.Data;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Models.JSONModels.RealtimeGameModels;
    using SomeDotes.Models.MainModels;
    using SomeDotes.Services.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class RegisterCurrentGameService : IRegisterCurrentGameService
    {
        private ICurrentGameService cgs;
        private IConvertSteamIdToAccountId converter;
        private bool isNewGame;

        public RegisterCurrentGameService()
        {
            converter = new ConvertSteamIdToAccountId();
            isNewGame = true;
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

        void OnNewGameState(CurrentGameStateService gs)
        {
            RootObject ro = gs.ParsedData;

            var steamIds = FindAllSteamIds(gs.ParsedData);

            if (isNewGame)
                UpdatePlayersData(steamIds);

            isNewGame = false;
        }

        private void UpdatePlayersData(List<string> steamIds)
        {
            foreach (var steamId in steamIds)
            {
                var currentPlayerAccountId = converter.SingleId(steamId);

                Player currentPlayer = new Player();

                using (SomeDotesDbContext db = new SomeDotesDbContext())
                {
                    var resultsForCurrentPlayer = db.Results.Where(r => r.Players.Any(p => p.AccountId.ToString() == currentPlayerAccountId)).Include(r => r.Players).ToList();

                    foreach (var result in resultsForCurrentPlayer)
                    {
                        if (result.RadiantWin && (result.Players.FirstOrDefault(p => p.AccountId.ToString() == currentPlayerAccountId).PlayerSlot < 5))
                            currentPlayer.Wins++;
                        else
                            currentPlayer.Losses++;
                    }
                }

                currentPlayer.WinRate = currentPlayer.Wins / currentPlayer.Losses * 100;
            }
        }

        private List<string> FindAllSteamIds(RootObject parsedData)
        {
            List<string> allSteamIds = new List<string>();

            // Some shit because of the json format
            allSteamIds.Add(parsedData.MainPlayer.RadiantTeam.Player0.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.RadiantTeam.Player1.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.RadiantTeam.Player2.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.RadiantTeam.Player3.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.RadiantTeam.Player4.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.DireTeam.Player5.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.DireTeam.Player6.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.DireTeam.Player7.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.DireTeam.Player8.SteamId);
            allSteamIds.Add(parsedData.MainPlayer.DireTeam.Player9.SteamId);

            return allSteamIds;
        }

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
    }
}
