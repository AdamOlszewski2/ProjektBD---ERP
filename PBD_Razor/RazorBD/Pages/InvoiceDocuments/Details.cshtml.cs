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
    public class DetailsInvoiceDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsInvoiceDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Invoicedocument Invoicedocument { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoicedocument = await _context.Invoicedocument
                .Include(i => i.Contractor)
                .Include(i => i.User).FirstOrDefaultAsync(m => m.Documentid == id);

            if (Invoicedocument == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
