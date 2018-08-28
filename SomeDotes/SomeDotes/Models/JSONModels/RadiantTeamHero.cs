namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class RadiantTeamHero
    {
        [JsonProperty("player0")]
        public HeroPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public HeroPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public HeroPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public HeroPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public HeroPlayer Player4 { get; set; }
    }
}
