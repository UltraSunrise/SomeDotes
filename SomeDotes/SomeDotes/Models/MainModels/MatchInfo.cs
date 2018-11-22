using SomeDotes.Models.JSONModels.RealtimeGameModels;
using System;
using System.Collections.Generic;

namespace SomeDotes.Models.MainModels
{
    public class MatchInfo
    {
        public long MatchID { get; set; }
        public long RadiantGold { get; set; }
        public long DireGold { get; set; }
        public long WinProbability { get; set; }
        public long RadiantKills { get; set; }
        public long DireKills { get; set; }
        public string MatchTime { get; set; }
        public string Hero0ImgDataUrl { get; set; }
        public string Hero1ImgDataUrl { get; set; }
        public string Hero2ImgDataUrl { get; set; }
        public string Hero3ImgDataUrl { get; set; }
        public string Hero4ImgDataUrl { get; set; }
        public string Hero5ImgDataUrl { get; set; }
        public string Hero6ImgDataUrl { get; set; }
        public string Hero7ImgDataUrl { get; set; }
        public string Hero8ImgDataUrl { get; set; }
        public string Hero9ImgDataUrl { get; set; }
        public List<RadiantSubPlayer> RadiantTeam { get; set; } = new List<RadiantSubPlayer>();
        public List<DireSubPlayer> DireTeam { get; set; } = new List<DireSubPlayer>();
        public List<string> HeroesImages { get; set; } = new List<string>();
        public List<long> HeroesNetWorth { get; set; } = new List<long>();
        public List<long> HeroesCurrentGold { get; set; } = new List<long>();
        public List<long> HeroesReliableGold { get; set; } = new List<long>();
        public List<long> HeroesBuybackCost { get; set; } = new List<long>();
        public List<long> HeroesBuybackCooldown { get; set; } = new List<long>();
        public List<bool> HeroesBuybackStatus { get; set; } = new List<bool>();
    }
}
