using Newtonsoft.Json;

namespace SomeDotes.Models.JSONModels
{
    public class MainPlayer
    {
        [JsonProperty("team2")]
        public RadiantTeamPlayer RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamPlayer DireTeam { get; set; }
    }
}
