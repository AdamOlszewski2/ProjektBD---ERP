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
    public class DeleteInvoiceDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DeleteInvoiceDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoicedocument = await _context.Invoicedocument.FindAsync(id);

            if (Invoicedocument != null)
            {
                _context.Invoicedocument.Remove(Invoicedocument);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
