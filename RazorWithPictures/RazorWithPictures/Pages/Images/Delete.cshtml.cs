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
    public class DeleteModel : PageModel
    {
        private readonly RazorWithPictures.Data.RazorWithPicturesContext _context;

        public DeleteModel(RazorWithPictures.Data.RazorWithPicturesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Image Image { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Image == null)
            {
                return NotFound();
            }

            var image = await _context.Image.FirstOrDefaultAsync(m => m.id == id);

            if (image == null)
            {
                return NotFound();
            }
            else 
            {
                Image = image;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Image == null)
            {
                return NotFound();
            }
            var image = await _context.Image.FindAsync(id);

            if (image != null)
            {
                Image = image;
                _context.Image.Remove(Image);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
