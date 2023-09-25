using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kryds_Bolle.Models;
using System.Numerics;

namespace Kryds_Bolle.Controllers
{
    public class GameController : Controller
    {
        public static Game game { get; set;}
        public static string symbol { get; set; }
        // GET: GameController
        public ActionResult Index()
        {
            if (game == null)
            {
                game = new Game();
                game.Board = new int[3, 3];
            }
            CheckPlayer();
            ViewBag.Player = HttpContext.Session.GetString("Player");
            ViewBag.PlayerSymbol = symbol;

            return View();
        }

        public void CheckPlayer()
        {
            if (HttpContext.Session.GetString("Player") == null)
            {
                RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("Player") == "1")
            {
                game.activePlayer = int.Parse(HttpContext.Session.GetString("Player"));
            }
            else if (HttpContext.Session.GetString("Player") == "2")
            {
                game.activePlayer = int.Parse(HttpContext.Session.GetString("Player"));
            }
            SetSymbol();
        }

        public void SetSymbol()
        {
            if(game.activePlayer == 1)
            {
                symbol = "X";
            }
            else if(game.activePlayer == 2)
            {
                symbol = "O";
            }
        }

        [HttpPost]
        public async Task<IActionResult> MyTurn([FromBody] Player player)
        {
            if(player.id == game.activePlayer.ToString())
            {
                player.reload = "true";
            }
            else
            {
                player.reload = "false";
            }
            return Json(player);
        }
        public class Player
        {
            public string id { get; set; }
            public string reload { get; set; }
        }

    }
}
