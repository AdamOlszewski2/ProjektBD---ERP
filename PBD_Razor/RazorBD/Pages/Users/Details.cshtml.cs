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
    public class DetailsUserModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public DetailsUserModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users
                .Include(u => u.Departament).FirstOrDefaultAsync(m => m.Userid == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
