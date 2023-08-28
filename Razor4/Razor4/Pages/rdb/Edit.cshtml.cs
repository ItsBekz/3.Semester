using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor4.Data;
using Razor4.Models;

namespace Razor4.Pages.rdb
{
    public class EditModel : PageModel
    {
        private readonly Razor4.Data.Razor4Context _context;

        public EditModel(Razor4.Data.Razor4Context context)
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

            var item2 =  await _context.Item2.FirstOrDefaultAsync(m => m.Id == id);
            if (item2 == null)
            {
                return NotFound();
            }
            Item2 = item2;
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

            _context.Attach(Item2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Item2Exists(Item2.Id))
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

        private bool Item2Exists(int id)
        {
          return (_context.Item2?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
