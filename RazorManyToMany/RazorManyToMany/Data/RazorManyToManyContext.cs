using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorManyToMany;

namespace RazorManyToMany.Data
{
    public class RazorManyToManyContext : DbContext
    {
        public RazorManyToManyContext (DbContextOptions<RazorManyToManyContext> options)
            : base(options)
        {
        }

        public DbSet<RazorManyToMany.Author>? Author { get; set; } = default!;

        public DbSet<RazorManyToMany.Book>? Book { get; set; }
    }
}
