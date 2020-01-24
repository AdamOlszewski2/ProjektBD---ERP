using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Product
    {
        public Product()
        {
            Invoicedocumentposition = new HashSet<Invoicedocumentposition>();
            Saledocumentposition = new HashSet<Saledocumentposition>();
        }

        public int Productid { get; set; }
        public long? Plu { get; set; }
        public string Name { get; set; }
        public byte Vatrateid { get; set; }
        public decimal Netprice { get; set; }
        public int Stock { get; set; }

        public virtual Vatrate Vatrate { get; set; }
        public virtual ICollection<Invoicedocumentposition> Invoicedocumentposition { get; set; }
        public virtual ICollection<Saledocumentposition> Saledocumentposition { get; set; }
    }
}
