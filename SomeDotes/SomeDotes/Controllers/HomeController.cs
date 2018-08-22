namespace SomeDotes.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SomeDotes.Models;
    using SomeDotes.Services;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Reader read = new Reader();
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
