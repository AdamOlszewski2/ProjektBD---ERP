using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Vatrate
    {
        public Vatrate()
        {
            Invoicedocumentposition = new HashSet<Invoicedocumentposition>();
            Product = new HashSet<Product>();
            Saledocumentposition = new HashSet<Saledocumentposition>();
        }

        public byte Vatrateid { get; set; }
        public float Vatrateamount { get; set; }

        public virtual ICollection<Invoicedocumentposition> Invoicedocumentposition { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Saledocumentposition> Saledocumentposition { get; set; }
    }
}
