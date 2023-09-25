using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorWithPictures.Data;
using RazorWithPictures.Models;

namespace RazorWithPictures.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly RazorWithPictures.Data.RazorWithPicturesContext _context;

        public CreateModel(RazorWithPictures.Data.RazorWithPicturesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Image Image { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Image == null || Image == null)
            {
                return Page();
            }

            _context.Image.Add(Image);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostUploadImage() 
        {
            foreach(var file in Request.Form.Files)
            {
                Image img = new Image();
                img.imageTitle = file.FileName;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.imageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Image.Add(img);
                _context.SaveChanges();
            }
            return RedirectToPage("./Index");
        }

    }
}
