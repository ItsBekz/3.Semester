using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorWithPictures.Data;
using RazorWithPictures.Models;

namespace RazorWithPictures.Pages.Images
{
    public class EditModel : PageModel
    {
        private readonly RazorWithPictures.Data.RazorWithPicturesContext _context;

        public EditModel(RazorWithPictures.Data.RazorWithPicturesContext context)
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

            var image =  await _context.Image.FirstOrDefaultAsync(m => m.id == id);
            if (image == null)
            {
                return NotFound();
            }
            Image = image;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(Image.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ImageExists(int id)
        {
          return (_context.Image?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
