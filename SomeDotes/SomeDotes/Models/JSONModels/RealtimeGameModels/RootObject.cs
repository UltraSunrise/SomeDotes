namespace SomeDotes.Models.JSONModels.RealtimeGameModels
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
        [JsonProperty("hero")]
        public Hero Hero { get; set; }
        [JsonProperty("abilities")]
        public Abilities Abilities { get; set; }
        [JsonProperty("items")]
        public Items Items { get; set; }
    }
}
