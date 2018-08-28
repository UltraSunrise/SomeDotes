namespace SomeDotes.Models.JSONModels.RealtimeGameModels
{
    using Newtonsoft.Json;

    public class RadiantTeamAbilities
    {
        [JsonProperty("player0")]
        public AbilitiesPlayer Player0 { get; set; }
        [JsonProperty("player1")]
        public AbilitiesPlayer Player1 { get; set; }
        [JsonProperty("player2")]
        public AbilitiesPlayer Player2 { get; set; }
        [JsonProperty("player3")]
        public AbilitiesPlayer Player3 { get; set; }
        [JsonProperty("player4")]
        public AbilitiesPlayer Player4 { get; set; }
    }
}
