namespace SomeDotes.ViewModels
{
    using SomeDotes.Helpers;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Services.DatabaseServices;
    using System.Collections.Generic;
    using System.Linq;

    public class PreGameViewModel
    {
        IDatabaseService dbService;
        public PreGameViewModel()
        {
            dbService = new DatabaseService();
            LoadData();
        }

        public List<HeroWinPercentageHelper> MostWinningHeroes { get; set; }
        public List<HeroWinPercentageHelper> MostLosingHeroes { get; set; }

        private void LoadData()
        {
            dbService = new DatabaseService();
            var heroesWinChance = dbService.GetAllHeroesWinChance();

            MostWinningHeroes = heroesWinChance.OrderByDescending(wc => wc.WinChance).Take(5).ToList();
            MostLosingHeroes = heroesWinChance.OrderBy(wc => wc.WinChance).Take(5).ToList();
        }
    }
}
