using SomeDotes.Models.MainModels;
using SomeDotes.Services.RealTimeService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SomeDotes.ViewModels
{
    using SomeDotes.Converters;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Models.JSONModels.RealtimeGameModels;
    using SomeDotes.Services.DatabaseServices;

    public class CurrentGameViewModel
    {
        #region Declaration

        private readonly string PRIVATE_ACCOUNT = "4294967295";

        private CurrentGameStateService gs;
        private IDatabaseService dbService;

        #endregion //Declaration

        #region Init

        public CurrentGameViewModel(CurrentGameStateService gs)
        {
            this.gs = gs;
            dbService = new DatabaseService();

            LoadData(gs);
        }

        #endregion //Init

        #region Properties

        public CurrentGameInfo CurrentMatchInfo { get; set; }

        #endregion //Properties

        #region Private Methods

        private void LoadData(CurrentGameStateService gs)
        {
            RootObject ro = gs.ParsedData;

            if (gs.ParsedData.Map == null)
            {
                return;
            }

            var steamIds = FindAllSteamIds(gs.ParsedData);
            CurrentGameInfo matchInfo = new CurrentGameInfo();

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

            matchInfo.HeroesImages = ImagesConverter.LoadImages(gs.ParsedData.Hero.AllHeroes.Select(ah => ah.Id).ToList());

            CurrentMatchInfo = matchInfo;
        }

        private List<string> FindAllSteamIds(RootObject parsedData)
        {
            List<string> allSteamIds = new List<string>();

            allSteamIds.AddRange(parsedData.MainPlayer.RadiantTeam.GetAllPlayers.Select(p => p.SteamId));
            allSteamIds.AddRange(parsedData.MainPlayer.DireTeam.GetAllPlayers.Select(p => p.SteamId));

            return allSteamIds.Where(asi => asi != PRIVATE_ACCOUNT).ToList();
        }
        #endregion //Private methods
    }
}
