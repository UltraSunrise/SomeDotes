namespace SomeDotes.Data.Entities
{
    using System.Collections.Generic;

    public class Match
    {
        public long MatchId { get; set; }
        public long MatchSeqNum { get; set; }
        public long StartTime { get; set; }
        public int LobbyType { get; set; }
        public int RadiantTeamId { get; set; }
        public int DireTeamId { get; set; }
        
        public int ResultId { get; set; }
        public Result Result { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
    }
}
