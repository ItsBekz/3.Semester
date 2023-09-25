using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorMedBilleder.Data;
using RazorMedBilleder.Models;

namespace RazorMedBilleder.Pages.Images
{
    public class CreateModel : PageModel
    {
        private readonly RazorMedBilleder.Data.RazorMedBillederContext _context;

        public CreateModel(RazorMedBilleder.Data.RazorMedBillederContext context)
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
    }
}
