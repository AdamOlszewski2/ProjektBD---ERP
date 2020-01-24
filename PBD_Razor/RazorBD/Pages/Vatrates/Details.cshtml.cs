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
    public class DetailsModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Vatrate Vatrate { get; set; }

        public async Task<IActionResult> OnGetAsync(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vatrate = await _context.Vatrate.FirstOrDefaultAsync(m => m.Vatrateid == id);

            if (Vatrate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
