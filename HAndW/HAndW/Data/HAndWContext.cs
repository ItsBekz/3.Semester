using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HAndW.Models;

namespace HAndW.Data
{
    public class HAndWContext : DbContext
    {
        public HAndWContext (DbContextOptions<HAndWContext> options)
            : base(options)
        {
        }

        public DbSet<HAndW.Models.House> House { get; set; } = default!;

        public DbSet<HAndW.Models.Window>? Window { get; set; }
    }
}
