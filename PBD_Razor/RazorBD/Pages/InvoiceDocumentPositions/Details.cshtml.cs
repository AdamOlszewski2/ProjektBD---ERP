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
    public class DetailsInvoiceDocumentPositionModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsInvoiceDocumentPositionModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Invoicedocumentposition Invoicedocumentposition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoicedocumentposition = await _context.Invoicedocumentposition
                .Include(i => i.Document)
                .Include(i => i.Product)
                .Include(i => i.Vatrate).FirstOrDefaultAsync(m => m.Invoicedocumentpositionid == id);

            if (Invoicedocumentposition == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
