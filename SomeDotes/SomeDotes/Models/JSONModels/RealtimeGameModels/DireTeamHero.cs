using System.Collections.Generic;

namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class DireTeamHero
    {
        private List<HeroPlayer> allPlayers;

        [JsonProperty("player5")]
        public HeroPlayer Player5 { get; set; }
        [JsonProperty("player6")]
        public HeroPlayer Player6 { get; set; }
        [JsonProperty("player7")]
        public HeroPlayer Player7 { get; set; }
        [JsonProperty("player8")]
        public HeroPlayer Player8 { get; set; }
        [JsonProperty("player9")]
        public HeroPlayer Player9 { get; set; }

        public List<HeroPlayer> AllPlayers
        {
            get
            {
                if (allPlayers == null)
                    allPlayers = new List<HeroPlayer>() { Player5, Player6, Player7, Player8, Player9 };

                return allPlayers;
            }
        }
    }
}
