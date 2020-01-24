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
    public class CreateUserModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public CreateUserModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Departamentid"] = new SelectList(_context.Departament, "Departamentid", "Name");
            return Page();
        }

        [BindProperty]
        public Users Users { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(Users);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
