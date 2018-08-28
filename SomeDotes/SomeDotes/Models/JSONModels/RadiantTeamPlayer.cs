namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class RadiantTeamPlayer
    {
        [JsonProperty("player0")]
        public RadiantSubPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public RadiantSubPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public RadiantSubPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public RadiantSubPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public RadiantSubPlayer Player4 { get; set; }
    }
}
