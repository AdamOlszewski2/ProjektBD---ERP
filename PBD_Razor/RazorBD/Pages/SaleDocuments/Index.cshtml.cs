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
    public class IndexSaleDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexSaleDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Saledocument> Saledocument { get;set; }

        public async Task OnGetAsync()
        {
            Saledocument = await _context.Saledocument
                .Include(s => s.Contractor)
                .Include(s => s.User).ToListAsync();
        }
    }
}
