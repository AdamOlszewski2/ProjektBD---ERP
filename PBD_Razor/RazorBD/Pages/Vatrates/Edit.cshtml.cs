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
    public class EditModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public EditModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vatrate Vatrate { get; set; }

        public async Task<IActionResult> OnGetAsync(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vatrate = await _context.Vatrate.FirstOrDefaultAsync(m => m.Vatrateid == id);

            if (Vatrate == null)
            {
                return NotFound();
            }
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

            _context.Attach(Vatrate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VatrateExists(Vatrate.Vatrateid))
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

        private bool VatrateExists(byte id)
        {
            return _context.Vatrate.Any(e => e.Vatrateid == id);
        }
    }
}
