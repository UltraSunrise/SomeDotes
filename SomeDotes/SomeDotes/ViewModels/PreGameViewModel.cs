namespace SomeDotes.ViewModels
{
    using Microsoft.Extensions.Caching.Memory;
    using SomeDotes.Converters;
    using SomeDotes.Helpers;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Services.DatabaseServices;
    using SomeDotes.Services.RealTimeService;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class PreGameViewModel
    {
        private const string LoadedDataCacheKey = "loadedDataCacheKey";
        private const string WinRateCacheKey = "winRateCacheKey";
        private const string LoseRateCacheKey = "loseRateCacheKey";

        private CurrentGameStateService gs;
        private IDatabaseService dbService;
        private IMemoryCache cache;

        public PreGameViewModel(IMemoryCache cache, CurrentGameStateService gs)
        {
            this.cache = cache;
            this.gs = gs;
            dbService = new DatabaseService();
        }

        public List<HeroWinPercentageHelper> MostWinningHeroes
        {
            get
            {
                return LoadHeroes();
            }
        }


        public List<HeroWinPercentageHelper> MostLosingHeroes
        {
            get
            {
                return LoadHeroes();
            }
        }

        //private void LoadData()
        //{
        //    if (DataLoaded())
        //    {
                

        //        if (cache.TryGetValue(LoseRateCacheKey, out List<HeroWinPercentageHelper> losingHeroes))
        //        {
        //            MostLosingHeroes = losingHeroes;
        //        }
        //    }

        //    cache.Set(LoadedDataCacheKey, true);

        //    dbService = new DatabaseService();
        //    var heroesWinChance = dbService.GetAllHeroesWinChance();

        //    MostWinningHeroes = heroesWinChance.OrderByDescending(wc => wc.WinChance).Take(10).ToList();
        //    MostLosingHeroes = heroesWinChance.OrderBy(wc => wc.WinChance).Take(10).ToList();

        //    string[] winningHeroImages = ImagesConverter.LoadImages(MostWinningHeroes);
        //    string[] losingHeroImages = ImagesConverter.LoadImages(MostLosingHeroes);

        //    for (int i = 0; i < winningHeroImages.Length; i++)
        //    {
        //        MostWinningHeroes[i].HeroImage = winningHeroImages[i];
        //        MostLosingHeroes[i].HeroImage = losingHeroImages[i];
        //    }

        //    cache.Set(WinRateCacheKey, MostWinningHeroes);
        //    cache.Set(LoseRateCacheKey, MostLosingHeroes);
        //}

        private List<HeroWinPercentageHelper> LoadHeroes()
        {
            List<HeroWinPercentageHelper> heroes = new List<HeroWinPercentageHelper>();
            var st = new StackTrace().GetFrame(1).GetMethod().Name;
            
            if (st == "get_MostWinningHeroes")
            {
                if (cache.TryGetValue(WinRateCacheKey, out heroes))
                {
                    return heroes;
                }

                var heroesWinChance = dbService.GetAllHeroesWinChance();
                heroes = heroesWinChance.OrderByDescending(wc => wc.WinChance).Take(10).ToList();
                string[] winningHeroImages = ImagesConverter.LoadImages(heroes);

                for (int i = 0; i < heroes.Count; i++)
                {
                    heroes[i].HeroImage = winningHeroImages[i];
                }

                cache.Set(WinRateCacheKey, heroes);
            }
            else if (st == "get_MostLosingHeroes")
            {
                if (cache.TryGetValue(LoseRateCacheKey, out heroes))
                {
                    return heroes;
                }

                var heroesWinChance = dbService.GetAllHeroesWinChance();
                heroes = heroesWinChance.OrderBy(wc => wc.WinChance).Take(10).ToList();
                string[] losingHeroImages = ImagesConverter.LoadImages(heroes);

                for (int i = 0; i < heroes.Count; i++)
                {
                    heroes[i].HeroImage = losingHeroImages[i];
                }

                cache.Set(LoseRateCacheKey, heroes);
            }


            return heroes;
        }
    }
}
