namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class ItemsPlayer
    {
        [JsonProperty("slot0")]
        public Slot Slot0 { get; set; }
        [JsonProperty("slot1")]
        public Slot Slot1 { get; set; }
        [JsonProperty("slot2")]
        public Slot Slot2 { get; set; }
        [JsonProperty("slot3")]
        public Slot Slot3 { get; set; }
        [JsonProperty("slot4")]
        public Slot Slot4 { get; set; }
        [JsonProperty("slot5")]
        public Slot Slot5 { get; set; }
        [JsonProperty("slot6")]
        public Slot Slot6 { get; set; }
        [JsonProperty("slot7")]
        public Slot Slot7 { get; set; }
        [JsonProperty("slot8")]
        public Slot Slot8 { get; set; }
        [JsonProperty("stash0")]
        public Slot Stash0 { get; set; }
        [JsonProperty("stash1")]
        public Slot Stash1 { get; set; }
        [JsonProperty("stash2")]
        public Slot Stash2 { get; set; }
        [JsonProperty("stash3")]
        public Slot Stash3 { get; set; }
        [JsonProperty("stash4")]
        public Slot Stash4 { get; set; }
        [JsonProperty("stash5")]
        public Slot Stash5 { get; set; }
    }
}
