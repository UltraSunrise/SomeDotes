namespace SomeDotes.Services.DatabaseServices
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SomeDotes.Data;
    using SomeDotes.Data.Entities;
    using SomeDotes.Helpers;
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

        public List<HeroDb> GetAllHeroes()
        {
            using (SomeDotesDbContext db = new SomeDotesDbContext())
            {
                return db
                        .Heroes
                        .ToList();
            }
        }

        public List<HeroWinPercentageHelper> GetAllHeroesWinChance()
        {
            Dictionary<int, HeroWinPercentageHelper> allHeroesWinChange = new Dictionary<int, HeroWinPercentageHelper>();

            using (SomeDotesDbContext db = new SomeDotesDbContext())
            {
                var tempList = db.Players.Select(p => new
                {
                    p.HeroId,
                    p.PlayerSlot,
                    p.Result.RadiantWin
                });

                foreach (var currentPlayer in tempList)
                {
                    var currentHeroId = currentPlayer.HeroId;

                    if (!allHeroesWinChange.Keys.Contains(currentHeroId))
                    {
                        allHeroesWinChange.Add(currentHeroId, new HeroWinPercentageHelper());
                        allHeroesWinChange[currentHeroId].HeroId = currentHeroId;
                    }

                    if ((currentPlayer.PlayerSlot < 50 && currentPlayer.RadiantWin) || (currentPlayer.PlayerSlot > 50 && !currentPlayer.RadiantWin))
                        allHeroesWinChange[currentHeroId].Wins++;
                    else
                        allHeroesWinChange[currentHeroId].Losses++;
                }

                foreach (var currentHero in allHeroesWinChange.Values)
                {
                    currentHero.WinChance = currentHero.Wins / (currentHero.Wins + currentHero.Losses);
                }

                return new List<HeroWinPercentageHelper>(allHeroesWinChange.Values);
            }
        }
    }
}
