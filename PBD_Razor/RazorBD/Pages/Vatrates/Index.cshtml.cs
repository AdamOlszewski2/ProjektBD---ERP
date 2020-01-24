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
    public class IndexVatrateModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexVatrateModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Vatrate> Vatrate { get;set; }

        public async Task OnGetAsync()
        {
            Vatrate = await _context.Vatrate.ToListAsync();
        }
    }
}
