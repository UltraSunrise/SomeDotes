namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class RadiantTeamItems
    {
        [JsonProperty("player0")]
        public ItemsPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public ItemsPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public ItemsPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public ItemsPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public ItemsPlayer Player4 { get; set; }
    }
}
