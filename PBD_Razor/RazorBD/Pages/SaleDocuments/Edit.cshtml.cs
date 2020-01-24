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
    public class EditSaleDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public EditSaleDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            _context.Attach(Saledocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaledocumentExists(Saledocument.Documentid))
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

        private bool SaledocumentExists(int id)
        {
            return _context.Saledocument.Any(e => e.Documentid == id);
        }
    }
}
