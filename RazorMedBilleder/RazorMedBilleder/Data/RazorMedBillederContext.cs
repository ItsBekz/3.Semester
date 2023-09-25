using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorMedBilleder.Models;

namespace RazorMedBilleder.Data
{
    public class RazorMedBillederContext : DbContext
    {
        public RazorMedBillederContext (DbContextOptions<RazorMedBillederContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMedBilleder.Models.Image> Image { get; set; } = default!;
    }
}
