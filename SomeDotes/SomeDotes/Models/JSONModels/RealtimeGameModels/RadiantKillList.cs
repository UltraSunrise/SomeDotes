namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class RadiantKillList
    {
        [JsonProperty("victimid_5")]
        public long Victim5 { get; set; }
        [JsonProperty("victimid_6")]
        public long Victim6 { get; set; }
        [JsonProperty("victimid_7")]
        public long Victim7 { get; set; }
        [JsonProperty("victimid_8")]
        public long Victim8 { get; set; }
        [JsonProperty("victimid_9")]
        public long Victim9 { get; set; }
    }
}
