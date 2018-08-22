namespace SomeDotes.Services.DatabaseServices
{
    using System.Collections.Generic;
    using System.Linq;
    using SomeDotes.Data;
    using SomeDotes.Data.Entities;
    using SomeDotes.Models.Intefaces;

    public class DatabaseService : IDatabaseService
    {
        public void AddJSONToDatabase(Result result)
        {
            using (SomeDotesDbContext db = new SomeDotesDbContext())
            {
                db
                    .Results
                    .Add(result);

                db.SaveChanges();
            }
        }

        public void AddRangeJSONToDatabase(List<Result> results)
        {
            using (SomeDotesDbContext db = new SomeDotesDbContext())
            {
                db
                    .Results
                    .AddRange(results);

                db.SaveChanges();
            }
        }

        public long GetLastAddedMatch()
        {
            using (SomeDotesDbContext db = new SomeDotesDbContext())
            {
                return db
                         .Results
                         .LastOrDefault()
                         .MatchId;
            }
        }
    }
}
