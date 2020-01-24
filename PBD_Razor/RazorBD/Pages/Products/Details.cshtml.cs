using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBD.Models;

namespace RazorBD
{
    public class DetailsProductModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsProductModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Vatrate).FirstOrDefaultAsync(m => m.Productid == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
