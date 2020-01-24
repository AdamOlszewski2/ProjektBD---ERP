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
    public class IndexInvoiceDocumentModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexInvoiceDocumentModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Invoicedocument> Invoicedocument { get;set; }

        public async Task OnGetAsync()
        {
            Invoicedocument = await _context.Invoicedocument
                .Include(i => i.Contractor)
                .Include(i => i.User).ToListAsync();
        }
    }
}
