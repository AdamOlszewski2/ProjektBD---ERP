using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorBD.Models;

namespace RazorBD
{
    public class CreateSaleDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public CreateSaleDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Contractorid"] = new SelectList(_context.Contractor, "Contractorid", "Name");
        ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Firstname");
            return Page();
        }

        [BindProperty]
        public Saledocument Saledocument { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Saledocument.Add(Saledocument);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
