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
    public class DeleteInvoiceDocumentPositionModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DeleteInvoiceDocumentPositionModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoicedocumentposition = await _context.Invoicedocumentposition.FindAsync(id);

            if (Invoicedocumentposition != null)
            {
                _context.Invoicedocumentposition.Remove(Invoicedocumentposition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
