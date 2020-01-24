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
    public class DetailsDepartamentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsDepartamentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Departament Departament { get; set; }

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departament = await _context.Departament.FirstOrDefaultAsync(m => m.Departamentid == id);

            if (Departament == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
