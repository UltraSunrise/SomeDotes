namespace SomeDotes.Models.MainModels
{
    using SomeDotes.Models.JSONModels.RealtimeGameModels;
    using System.Collections.Generic;

    public class CurrentGameInfo
    {
        public long MatchID { get; set; }
        public long RadiantGold { get; set; }
        public long DireGold { get; set; }
        public long WinProbability { get; set; }
        public long RadiantKills { get; set; }
        public long DireKills { get; set; }
        public string MatchTime { get; set; }
        public List<RadiantSubPlayer> RadiantTeam { get; set; } = new List<RadiantSubPlayer>();
        public List<DireSubPlayer> DireTeam { get; set; } = new List<DireSubPlayer>();
        public string[] HeroesImages { get; set; } = new string[10];
        public List<long> HeroesNetWorth { get; set; } = new List<long>();
        public List<long> HeroesCurrentGold { get; set; } = new List<long>();
        public List<long> HeroesReliableGold { get; set; } = new List<long>();
        public List<long> HeroesBuybackCost { get; set; } = new List<long>();
        public List<long> HeroesBuybackCooldown { get; set; } = new List<long>();
        public List<bool> HeroesBuybackStatus { get; set; } = new List<bool>();
    }
}
