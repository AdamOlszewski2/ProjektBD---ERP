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
    public class CreateSaleDocumentPositionsModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public CreateSaleDocumentPositionsModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Documentid"] = new SelectList(_context.Saledocument, "Documentid", "Documentnumber");
        ViewData["Productid"] = new SelectList(_context.Product, "Productid", "Name");
        ViewData["Vatrateid"] = new SelectList(_context.Vatrate, "Vatrateid", "Vatrateid");
            return Page();
        }

        [BindProperty]
        public Saledocumentposition Saledocumentposition { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Saledocumentposition.Add(Saledocumentposition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
