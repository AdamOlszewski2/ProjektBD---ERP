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
    public class IndexDepartamentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexDepartamentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; }

        public async Task OnGetAsync()
        {
            Departament = await _context.Departament.ToListAsync();
        }
    }
}
