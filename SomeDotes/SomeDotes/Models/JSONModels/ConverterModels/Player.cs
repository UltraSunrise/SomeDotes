namespace SomeDotes.Models.JSONModels.ConverterModels
{
    using Newtonsoft.Json;

    public class Player
    {
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("player_slot")]
        public long PlayerSlot { get; set; }

        [JsonProperty("hero_id")]
        public long HeroId { get; set; }
    }
}
