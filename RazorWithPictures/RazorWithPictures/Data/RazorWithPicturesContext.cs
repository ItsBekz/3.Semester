using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorWithPictures.Models;

namespace RazorWithPictures.Data
{
    public class RazorWithPicturesContext : DbContext
    {
        public RazorWithPicturesContext (DbContextOptions<RazorWithPicturesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorWithPictures.Models.Image> Image { get; set; } = default!;
    }
}
