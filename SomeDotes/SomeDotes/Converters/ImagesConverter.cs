using SomeDotes.Data.Entities;
using SomeDotes.Helpers;
using SomeDotes.Models.Intefaces;
using SomeDotes.Models.MainModels;
using SomeDotes.Services.DatabaseServices;
using SomeDotes.Services.Helpers;
using SomeDotes.Services.RealTimeService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SomeDotes.Converters
{
    public static class ImagesConverter
    {
        private static IDatabaseService dbService;
        
        public static string[] LoadImages(List<long> ids)
        {
            dbService = new DatabaseService();
            ImagesHelper imagesHelper = ImagesHelper.GetInstance();

            if (!imagesHelper.AreAllAdded)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    if (imagesHelper.AllImages[i] == null)
                    {
                        imagesHelper.AllImages[i] = ConvertByteArrayToString(GetHero(ids[i]));
                    }
                    if (imagesHelper.AllImages.Where(ai => ai == null).Count() == 0)
                        imagesHelper.AreAllAdded = true;
                }
            }
            return imagesHelper.AllImages;
        }

        public static string[] LoadImages(List<HeroWinPercentageHelper> allHeroes)
        {
            dbService = new DatabaseService();
            string[] images = new string[allHeroes.Count];
            
                for (int i = 0; i < allHeroes.Count; i++)
                {
                    if (images[i] == null)
                    {
                        images[i] = ConvertByteArrayToString(GetHero(allHeroes[i].HeroId));
                    }
                }

            return images;
        }

        private static HeroDb GetHero(long id)
        {
            var currentHero = dbService.GetAllHeroes().FirstOrDefault(h => h.HeroId == id);

            return currentHero;
        }


        private static string ConvertByteArrayToString(HeroDb hero)
        {
            return string.Format("data:image/png;base64,{0}",
                Convert.ToBase64String(hero?.ImageFull));
        }
    }
}
