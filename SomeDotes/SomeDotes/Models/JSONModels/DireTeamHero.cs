namespace SomeDotes.Models.JSONModels
{
    using Newtonsoft.Json;

    public class DireTeamHero
    {
        [JsonProperty("player5")]
        public HeroPlayer Player5 { get; set; }
        [JsonProperty("player6")]
        public HeroPlayer Player6 { get; set; }
        [JsonProperty("player7")]
        public HeroPlayer Player7 { get; set; }
        [JsonProperty("player8")]
        public HeroPlayer Player8 { get; set; }
        [JsonProperty("player9")]
        public HeroPlayer Player9 { get; set; }
    }
}
