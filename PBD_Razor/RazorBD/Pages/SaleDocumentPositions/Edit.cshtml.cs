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
    public class EditSaleDocumentPositionsModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public EditSaleDocumentPositionsModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Documentid"] = new SelectList(_context.Saledocument, "Documentid", "Documentnumber");
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

            _context.Attach(Saledocumentposition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaledocumentpositionExists(Saledocumentposition.Saledocumentpositionid))
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

        private bool SaledocumentpositionExists(int id)
        {
            return _context.Saledocumentposition.Any(e => e.Saledocumentpositionid == id);
        }
    }
}
