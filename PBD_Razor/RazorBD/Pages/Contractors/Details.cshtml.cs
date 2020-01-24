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
    public class DetailsContractorModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsContractorModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Contractor Contractor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contractor = await _context.Contractor.FirstOrDefaultAsync(m => m.Contractorid == id);

            if (Contractor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
