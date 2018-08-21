namespace SomeDotes.Data.Entities
{
    using System.Collections.Generic;

    public class Result
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int NumResults { get; set; }
        public int TotalResults { get; set; }
        public int ResultsRemaining { get; set; }

        public List<Match> Matches { get; set; } = new List<Match>();
    }
}
