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
    public class DetailsSaleDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsSaleDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Saledocument Saledocument { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Saledocument = await _context.Saledocument
                .Include(s => s.Contractor)
                .Include(s => s.User).FirstOrDefaultAsync(m => m.Documentid == id);

            if (Saledocument == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
