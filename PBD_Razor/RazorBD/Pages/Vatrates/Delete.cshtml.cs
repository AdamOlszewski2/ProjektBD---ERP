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
    public class DeleteModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DeleteModel(RazorBD.Models.ProjektBDContext context)
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

        public async Task<IActionResult> OnPostAsync(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vatrate = await _context.Vatrate.FindAsync(id);

            if (Vatrate != null)
            {
                _context.Vatrate.Remove(Vatrate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
