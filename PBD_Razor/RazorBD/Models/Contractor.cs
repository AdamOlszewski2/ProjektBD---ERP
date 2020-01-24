using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            Invoicedocument = new HashSet<Invoicedocument>();
            Saledocument = new HashSet<Saledocument>();
        }

        public int Contractorid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long Nip { get; set; }
        public int? Bankaccount { get; set; }

        public virtual ICollection<Invoicedocument> Invoicedocument { get; set; }
        public virtual ICollection<Saledocument> Saledocument { get; set; }
    }
}
