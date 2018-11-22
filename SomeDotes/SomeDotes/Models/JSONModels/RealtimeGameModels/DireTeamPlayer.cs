using System.Collections.Generic;

namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class DireTeamPlayer
    {
        private List<DireSubPlayer> getAllPlayers;
        [JsonProperty("player5")]
        public DireSubPlayer Player5 { get; set; }
        [JsonProperty("player6")]
        public DireSubPlayer Player6 { get; set; }
        [JsonProperty("player7")]
        public DireSubPlayer Player7 { get; set; }
        [JsonProperty("player8")]
        public DireSubPlayer Player8 { get; set; }
        [JsonProperty("player9")]
        public DireSubPlayer Player9 { get; set; }

        public List<DireSubPlayer> GetAllPlayers => getAllPlayers ?? (getAllPlayers = new List<DireSubPlayer>()
                                                        {Player5, Player6, Player7, Player8, Player9});
    }
}
