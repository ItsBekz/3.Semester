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
    public class IndexModel : PageModel
    {
        private readonly Razor4.Data.Razor4Context _context;

        public IndexModel(Razor4.Data.Razor4Context context)
        {
            _context = context;
        }

        public IList<Item2> Item2 { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Item2 != null)
            {
                Item2 = await _context.Item2.ToListAsync();
            }
        }
    }
}
