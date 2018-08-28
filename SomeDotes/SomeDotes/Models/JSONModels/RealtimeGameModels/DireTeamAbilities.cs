namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class DireTeamAbilities
    {
        [JsonProperty("player5")]
        public AbilitiesPlayer Player5 { get; set; }
        [JsonProperty("player6")]
        public AbilitiesPlayer Player6 { get; set; }
        [JsonProperty("player7")]
        public AbilitiesPlayer Player7 { get; set; }
        [JsonProperty("player8")]
        public AbilitiesPlayer Player8 { get; set; }
        [JsonProperty("player9")]
        public AbilitiesPlayer Player9 { get; set; }
    }
}
