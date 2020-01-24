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
    public class DetailsSaleDocumentPositionsModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsSaleDocumentPositionsModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Saledocumentposition Saledocumentposition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Saledocumentposition = await _context.Saledocumentposition
                .Include(s => s.Document)
                .Include(s => s.Product)
                .Include(s => s.Vatrate).FirstOrDefaultAsync(m => m.Saledocumentpositionid == id);

            if (Saledocumentposition == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
