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
    public class DetailsModel : PageModel
    {
        private readonly RazorMedBilleder.Data.RazorMedBillederContext _context;

        public DetailsModel(RazorMedBilleder.Data.RazorMedBillederContext context)
        {
            _context = context;
        }

      public Image Image { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Image == null)
            {
                return NotFound();
            }

            var image = await _context.Image.FirstOrDefaultAsync(m => m.id == id);
            if (image == null)
            {
                return NotFound();
            }
            else 
            {
                Image = image;
            }
            return Page();
        }
    }
}
