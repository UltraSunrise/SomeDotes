namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class DireTeamItems
    {
        [JsonProperty("player5")]
        public ItemsPlayer Player5 { get; set; }
        [JsonProperty("player6")]
        public ItemsPlayer Player6 { get; set; }
        [JsonProperty("player7")]
        public ItemsPlayer Player7 { get; set; }
        [JsonProperty("player8")]
        public ItemsPlayer Player8 { get; set; }
        [JsonProperty("player9")]
        public ItemsPlayer Player9 { get; set; }
    }
}
