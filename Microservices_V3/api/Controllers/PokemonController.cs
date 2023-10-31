using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/pokemon/{pokemonName}")]
        public IActionResult GetPokemonData(string pokemonName)
        {
            // Retrieve Pokemon data from the database based on the pokemonName
            // You should implement this logic using your database access methods

            var pokemon = GetPokemonDataFromDatabase(pokemonName);

            if (pokemon != null)
            {
                return Ok(pokemon); // Return Pokémon data as JSON
            }
            else
            {
                return NotFound();
            }
        }
    }
}
