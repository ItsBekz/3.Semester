using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API1.Models;

namespace API1.Data
{
    public class API1Context : DbContext
    {
        public API1Context (DbContextOptions<API1Context> options)
            : base(options)
        {
        }

        public DbSet<API1.Models.Car> Car { get; set; } = default!;
    }
}
