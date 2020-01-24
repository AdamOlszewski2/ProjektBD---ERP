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
    public class IndexInvoiceDocumentPositionModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexInvoiceDocumentPositionModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Invoicedocumentposition> Invoicedocumentposition { get;set; }

        public async Task OnGetAsync()
        {
            Invoicedocumentposition = await _context.Invoicedocumentposition
                .Include(i => i.Document)
                .Include(i => i.Product)
                .Include(i => i.Vatrate).ToListAsync();
        }
    }
}
