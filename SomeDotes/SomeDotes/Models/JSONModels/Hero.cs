namespace SomeDotes.Models.JSONModels
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
