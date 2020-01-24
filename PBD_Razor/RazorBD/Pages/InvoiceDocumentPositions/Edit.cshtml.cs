using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorBD.Models;

namespace RazorBD
{
    public class EditInvoiceDocumentPositionModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public EditInvoiceDocumentPositionModel(RazorBD.Models.ProjektBDContext context)
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
           ViewData["Documentid"] = new SelectList(_context.Invoicedocument, "Documentid", "Documentnumber");
           ViewData["Productid"] = new SelectList(_context.Product, "Productid", "Name");
           ViewData["Vatrateid"] = new SelectList(_context.Vatrate, "Vatrateid", "Vatrateid");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Invoicedocumentposition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicedocumentpositionExists(Invoicedocumentposition.Invoicedocumentpositionid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvoicedocumentpositionExists(int id)
        {
            return _context.Invoicedocumentposition.Any(e => e.Invoicedocumentpositionid == id);
        }
    }
}
