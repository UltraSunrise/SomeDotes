namespace SomeDotes.Models.JSONModels.ConverterModels
{
    using Newtonsoft.Json;

    public class Match
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("match_seq_num")]
        public long MatchSeqNum { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("lobby_type")]
        public long LobbyType { get; set; }

        [JsonProperty("radiant_team_id")]
        public long RadiantTeamId { get; set; }

        [JsonProperty("dire_team_id")]
        public long DireTeamId { get; set; }

        [JsonProperty("players")]
        public Player[] Players { get; set; }
    }
}