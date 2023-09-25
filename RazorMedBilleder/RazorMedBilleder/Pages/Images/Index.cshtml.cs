using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorMedBilleder.Data;
using RazorMedBilleder.Models;

namespace RazorMedBilleder.Pages.Images
{
    public class IndexModel : PageModel
    {
        private readonly RazorMedBilleder.Data.RazorMedBillederContext _context;

        public IndexModel(RazorMedBilleder.Data.RazorMedBillederContext context)
        {
            _context = context;
        }

        public IList<Image> Image { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Image != null)
            {
                Image = await _context.Image.ToListAsync();
            }
        }
    }
}
