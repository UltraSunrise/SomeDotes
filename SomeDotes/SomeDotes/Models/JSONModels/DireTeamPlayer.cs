namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class DireTeamPlayer
    {
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
    }
}
