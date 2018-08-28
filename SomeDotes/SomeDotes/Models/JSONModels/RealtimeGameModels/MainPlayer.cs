namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class MainPlayer
    {
        [JsonProperty("team2")]
        public RadiantTeamPlayer RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamPlayer DireTeam { get; set; }
    }
}
