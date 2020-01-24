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
    public class IndexContractorModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexContractorModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Contractor> Contractor { get;set; }

        public async Task OnGetAsync()
        {
            Contractor = await _context.Contractor.ToListAsync();
        }
    }
}
