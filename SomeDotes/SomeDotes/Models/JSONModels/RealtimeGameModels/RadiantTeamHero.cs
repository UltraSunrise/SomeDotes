using System.Collections.Generic;

namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class RadiantTeamHero
    {
        private List<HeroPlayer> allPlayers;

        [JsonProperty("player0")]
        public HeroPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public HeroPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public HeroPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public HeroPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public HeroPlayer Player4 { get; set; }

        public List<HeroPlayer> AllPlayers
        {
            get
            {
                if (allPlayers == null)
                    allPlayers = new List<HeroPlayer>() { Player0, Player1, Player2, Player3, Player4 };

                return allPlayers;
            }
        }
    }
}
