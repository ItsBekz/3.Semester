using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class PokemonsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new PokemonViewModel
            {
                AvailablePokemons = GetAvailablePokemons()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetPokemonData(PokemonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Send message to API
                // handle respons from API
            }

            viewModel.AvailablePokemons = GetAvailablePokemons();
            return View("Index", viewModel);
        }

        private List<string> GetAvailablePokemons()
        {
            throw new NotImplementedException();
        }
    }
}
