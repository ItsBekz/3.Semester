using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor4.Data;
using Razor4.Models;

namespace Razor4.Pages.rdb
{
    public class DeleteModel : PageModel
    {
        private readonly Razor4.Data.Razor4Context _context;

        public DeleteModel(Razor4.Data.Razor4Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Item2 Item2 { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item2 == null)
            {
                return NotFound();
            }

            var item2 = await _context.Item2.FirstOrDefaultAsync(m => m.Id == id);

            if (item2 == null)
            {
                return NotFound();
            }
            else 
            {
                Item2 = item2;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Item2 == null)
            {
                return NotFound();
            }
            var item2 = await _context.Item2.FindAsync(id);

            if (item2 != null)
            {
                Item2 = item2;
                _context.Item2.Remove(Item2);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
