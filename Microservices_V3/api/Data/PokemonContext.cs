using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) 
        { 
        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
