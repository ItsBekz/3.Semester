using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorManyToMany;
using RazorManyToMany.Data;

namespace RazorManyToMany.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly RazorManyToMany.Data.RazorManyToManyContext _context;

        public DetailsModel(RazorManyToMany.Data.RazorManyToManyContext context)
        {
            _context = context;
        }

      public Author Author { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.id == id);
            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }
    }
}
