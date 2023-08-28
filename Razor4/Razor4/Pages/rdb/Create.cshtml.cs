using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor4.Data;
using Razor4.Models;

namespace Razor4.Pages.rdb
{
    public class CreateModel : PageModel
    {
        private readonly Razor4.Data.Razor4Context _context;

        public CreateModel(Razor4.Data.Razor4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item2 Item2 { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Item2 == null || Item2 == null)
            {
                return Page();
            }

            _context.Item2.Add(Item2);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
