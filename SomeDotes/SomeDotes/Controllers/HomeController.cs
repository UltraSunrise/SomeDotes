namespace SomeDotes.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SomeDotes.Models;
    using SomeDotes.Models.Interfaces;
    using SomeDotes.Services.HistoryServices;
    using SomeDotes.Services.RealTimeService;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //IRegisterCurrentGameService cgs = new RegisterCurrentGameService();
            //cgs.Run();
            IPastGamesService read = new PastGamesService();
            read.ReadXMLAsync();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
    }
}
