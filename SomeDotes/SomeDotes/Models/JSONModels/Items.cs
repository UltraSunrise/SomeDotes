namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class Items
    {
        [JsonProperty("team2")]
        public RadiantTeamItems RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamItems DireTeam { get; set; }
    }
}
