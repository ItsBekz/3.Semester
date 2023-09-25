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
            if (symbol == null)
            {
                SetSymbol();
            }
            
            ViewBag.Player = HttpContext.Session.GetString("Player");
            ViewBag.PlayerSymbol = symbol;

            return View();
        }

        [HttpPost]
        public ActionResult UpdateBoard([FromBody] Player player, [FromBody] Board board)
        {
            try
            {
                for(int i = 0; i < game.Board.GetLength(0); i++)
                {
                    for(int j = 0; j < game.Board.GetLength(1); j++)
                    {
                        if(i == board.row && j == board.col)
                        {
                            game.Board[i, j] = int.Parse(player.id);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void CheckPlayer()
        {
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
                game.activePlayer = game.activePlayer == 1 ? 2 : 1;
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

        public class Board 
        {
            public int row { get; set; }
            public int col { get; set; }
        }
    }
}
