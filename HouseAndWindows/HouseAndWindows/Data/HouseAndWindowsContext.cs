using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HouseAndWindows.Models;

namespace HouseAndWindows.Data
{
    public class HouseAndWindowsContext : DbContext
    {
        public HouseAndWindowsContext (DbContextOptions<HouseAndWindowsContext> options)
            : base(options)
        {
        }

        public DbSet<HouseAndWindows.Models.House> House { get; set; } = default!;

        public DbSet<HouseAndWindows.Models.Window>? Window { get; set; }
    }
}
