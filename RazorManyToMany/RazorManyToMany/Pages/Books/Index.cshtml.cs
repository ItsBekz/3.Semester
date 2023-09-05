using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorManyToMany;
using RazorManyToMany.Data;

namespace RazorManyToMany.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorManyToMany.Data.RazorManyToManyContext _context;

        public IndexModel(RazorManyToMany.Data.RazorManyToManyContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.Include(e => e.authors).ToListAsync();
            }
        }
    }
}
