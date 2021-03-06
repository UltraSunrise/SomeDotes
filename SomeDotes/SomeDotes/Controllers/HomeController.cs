﻿namespace SomeDotes.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SomeDotes.Models;
    using SomeDotes.Models.Intefaces;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Services.DatabaseServices;
    using SomeDotes.Services.RealTimeService;
    
    public class HomeController : Controller
    {
        IRegisterCurrentGameService rcgs;
        IPreGameStatisticsService pgss;

        public HomeController(IRegisterCurrentGameService rcgs, IPreGameStatisticsService pgss)
        {
            this.rcgs = rcgs;
            this.pgss = pgss;
        }

        public IActionResult CurrentGame()
        {
            rcgs.Run();

            return View();
        }
        
        public IActionResult _RefreshCurrentGame()
        {            
            return PartialView("_RefreshCurrentGame", rcgs.MatchInfo());
        }

        public IActionResult PreGame()
        {
            return View(pgss.PreGameViewModel);
        }

        public IActionResult _RefreshPreGame()
        {
            return PartialView("_RefreshPreGame", pgss.PreGameViewModel);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public JsonResult UpdateInfo()
        {
            if (rcgs.MatchInfo() == null)
                return Json(null);
            return Json(null);
        }
    }
}
