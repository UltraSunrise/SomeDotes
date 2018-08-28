namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class DireKillList
    {
        [JsonProperty("victimid_0")]
        public long Victim0 { get; set; }
        [JsonProperty("victimid_1")]
        public long Victim1 { get; set; }
        [JsonProperty("victimid_2")]
        public long Victim2 { get; set; }
        [JsonProperty("victimid_3")]
        public long Victim3 { get; set; }
        [JsonProperty("victimid_4")]
        public long Victim4 { get; set; }
    }
}
