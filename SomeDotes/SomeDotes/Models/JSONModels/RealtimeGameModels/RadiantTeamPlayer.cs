using System.Collections.Generic;

namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class RadiantTeamPlayer
    {
        private List<RadiantSubPlayer> getAllPlayers;

        [JsonProperty("player0")]
        public RadiantSubPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public RadiantSubPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public RadiantSubPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public RadiantSubPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public RadiantSubPlayer Player4 { get; set; }

        public List<RadiantSubPlayer> GetAllPlayers => getAllPlayers ?? (getAllPlayers = new List<RadiantSubPlayer>()
                                                           {Player0, Player1, Player2, Player3, Player4});
    }
}
