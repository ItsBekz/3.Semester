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

            ViewBag.ActivePlayer = game.activePlayer;
            
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

        [HttpPost]
        public IActionResult TakeTurn(int row, int col)
        {
            Console.WriteLine("taking my turn, player: " + ViewBag.Player + " row: " + row + " col: " + col);
            int player = int.Parse(HttpContext.Session.GetString("Player"));
            if(player == game.activePlayer)
            {
                game.board[row, col] = player;
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PlayerChange([FromBody] Player player)
        {
            if(player.id == game.activePlayer)
            {
                player.refreshStatus = "true";
                if(game.activePlayer == int.Parse(HttpContext.Session.GetString("Player"))){
                    game.activePlayer = (game.activePlayer == 1) ? 2 : 1;
                }
                
            }
            else
            {
                player.refreshStatus = "false";
            }
            return Json(player);
        }

        public class Player
        {
            public int id { get; set; }
            public string refreshStatus { get; set; }
        }


        // GET: TicTacToeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicTacToeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
