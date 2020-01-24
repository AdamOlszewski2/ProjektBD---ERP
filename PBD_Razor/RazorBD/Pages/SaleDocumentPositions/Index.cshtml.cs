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
    public class IndexSaleDocumentPositionsModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexSaleDocumentPositionsModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Saledocumentposition> Saledocumentposition { get;set; }

        public async Task OnGetAsync()
        {
            Saledocumentposition = await _context.Saledocumentposition
                .Include(s => s.Document)
                .Include(s => s.Product)
                .Include(s => s.Vatrate).ToListAsync();
        }
    }
}
