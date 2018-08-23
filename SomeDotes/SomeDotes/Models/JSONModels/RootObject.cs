namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class RootObject
    {
        [JsonProperty("provider")]
        public Provider Provider { get; set; }
        [JsonProperty("map")]
        public Map Map { get; set; }
        [JsonProperty("player")]
        public MainPlayer MainPlayer { get; set; }
    }
}
