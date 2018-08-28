namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class Abilities
    {
        [JsonProperty("team2")]
        public RadiantTeamAbilities RadiantTeam { get; set; }
        [JsonProperty("team3")]
        public DireTeamAbilities DireTeam { get; set; }
    }
}
