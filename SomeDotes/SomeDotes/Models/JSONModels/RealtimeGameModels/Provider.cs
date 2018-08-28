namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class Provider
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("appid")]
        public long AppId { get; set; }
        [JsonProperty("version")]
        public long Version { get; set; }
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
    }
}