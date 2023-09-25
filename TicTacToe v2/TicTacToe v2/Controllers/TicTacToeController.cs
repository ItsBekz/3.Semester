using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel;
using TicTacToe_v2.Models;

namespace TicTacToe_v2.Controllers
{
    public class TicTacToeController : Controller
    {
        public static TicTacToe game { get; set; }
        // GET: TicTacToeController
        public ActionResult Index()
        {
            if (game == null)
            {
                game = new TicTacToe();
                game.board = new int[3, 3];
                game.activePlayer = 1;
            }
            
            ViewBag.Player = HttpContext.Session.GetString("Player");
            if(HttpContext.Session.GetString("Player") == "1")
            {
                ViewBag.PlayerSymbol = "X";
            }
            else
            {
                ViewBag.PlayerSymbol = "O";
            }
            return View();
        }

        public static int SpaceTaken(int row, int col)
        {
            return game.board[row, col];
        }



        [HttpPost]
        public async Task<IActionResult> TakeTurn(int row, int col)
        {
            Console.WriteLine("taking my turn, player: " + ViewBag.Player + " row: " + row + " col: " + col);
            int playerId = Int32.Parse(HttpContext.Session.GetString("Player"));
            if (playerId == game.activePlayer)
            {
                game.board[row, col] = game.activePlayer;
                game.activePlayer = (game.activePlayer == 1) ? 2 : 1;
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PlayerChange([FromBody] Player player)
        {
            if(player.name == game.activePlayer.ToString())
            {
                player.name = "true";
            }
            else
            {
                player.name = "false";
            }
            return Json(player);
        }

        public class Player
        {
            public string name { get; set; }
        }
    }
}
