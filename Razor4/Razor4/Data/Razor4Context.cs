using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor4.Models;

namespace Razor4.Data
{
    public class Razor4Context : DbContext
    {
        public Razor4Context (DbContextOptions<Razor4Context> options)
            : base(options)
        {
        }

        public DbSet<Razor4.Models.Item2> Item2 { get; set; } = default!;
    }
}
