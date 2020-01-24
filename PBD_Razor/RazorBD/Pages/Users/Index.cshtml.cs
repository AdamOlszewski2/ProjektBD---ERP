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
    public class IndexUserModel : PageModel
    {
        private readonly RazorBD.Models.ProjektBDContext _context;

        public IndexUserModel(RazorBD.Models.ProjektBDContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users
                .Include(u => u.Departament).ToListAsync();
        }
    }
}
