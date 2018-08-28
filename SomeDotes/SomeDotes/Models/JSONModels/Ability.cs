namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class Ability
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("level")]
        public long Level { get; set; }
        [JsonProperty("can_cast")]
        public bool CanCast { get; set; }
        [JsonProperty("passive")]
        public bool Passive { get; set; }
        [JsonProperty("ability_active")]
        public bool AbilityActive { get; set; }
        [JsonProperty("cooldown")]
        public long Cooldown { get; set; }
        [JsonProperty("ultimate")]
        public bool Ultimate { get; set; }
    }
}
