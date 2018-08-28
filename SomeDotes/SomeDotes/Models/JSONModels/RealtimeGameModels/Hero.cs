namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class Hero
    {
        [JsonProperty("team2")]
        public RadiantTeamHero RadintTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamHero DireTeam { get; set; }
    }
}
