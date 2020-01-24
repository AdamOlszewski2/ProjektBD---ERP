using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Departament
    {
        public Departament()
        {
            Users = new HashSet<Users>();
        }

        public short Departamentid { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
