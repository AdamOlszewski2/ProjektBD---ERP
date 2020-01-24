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
    public class EditInvoiceDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public EditInvoiceDocumentModel(RazorBD.Models.ProjektBDContext context)
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
           ViewData["Contractorid"] = new SelectList(_context.Contractor, "Contractorid", "Name");
           ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Firstname");
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

            _context.Attach(Invoicedocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicedocumentExists(Invoicedocument.Documentid))
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

        private bool InvoicedocumentExists(int id)
        {
            return _context.Invoicedocument.Any(e => e.Documentid == id);
        }
    }
}
