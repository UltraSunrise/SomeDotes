namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class Slot
    {
        [JsonProperty("name")]
        public string Name { get; set; }        
        [JsonProperty("purchaser")]
        public long Purchaser { get; set; }     
        [JsonProperty("can_cast")]
        public long CanCast { get; set; }       
        [JsonProperty("cooldown")]
        public long Cooldown { get; set; }
        [JsonProperty("passive")]
        public bool Passive { get; set; }
    }
}
