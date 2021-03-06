﻿namespace SomeDotes.Models.Intefaces
{
    using SomeDotes.Data.Entities;
    using SomeDotes.Helpers;
    using System.Collections.Generic;

    interface IDatabaseService
    {
        void AddJSONToDatabase(Result result);
        void AddRangeJSONToDatabase(List<Result> results);
        long GetLastAddedMatch();
        List<HeroDb> GetAllHeroes();
        List<HeroWinPercentageHelper> GetAllHeroesWinChance();
    }
}
