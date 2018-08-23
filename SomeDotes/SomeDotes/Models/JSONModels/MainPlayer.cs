using Newtonsoft.Json;

namespace SomeDotes.Models.JSONModels
{
    public class MainPlayer
    {
        [JsonProperty("team2")]
        public RadiantTeam RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeam DireTeam { get; set; }
    }
}
