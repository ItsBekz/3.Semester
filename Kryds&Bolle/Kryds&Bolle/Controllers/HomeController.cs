using Kryds_Bolle.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kryds_Bolle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int player = 1;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Player") == null)
            {
                HttpContext.Session.SetString("Player",$"{player}");
                ViewBag.Message = player;
                player++;
            }
            else
            {
                ViewBag.Message = HttpContext.Session.GetString("Player");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}