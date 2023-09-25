using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorWithPictures.Data;
using RazorWithPictures.Models;

namespace RazorWithPictures.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly RazorWithPictures.Data.RazorWithPicturesContext _context;

        public IndexModel(RazorWithPictures.Data.RazorWithPicturesContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Image != null)
            {
                Image = await _context.Image.ToListAsync();
            }
        }
    }
}
