using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Saledocument
    {
        public Saledocument()
        {
            Saledocumentposition = new HashSet<Saledocumentposition>();
        }

        public int Documentid { get; set; }
        public string Documentnumber { get; set; }
        public int Contractorid { get; set; }
        public int Userid { get; set; }
        public DateTime Moddate { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Invoicedate { get; set; }
        public decimal Grosssum { get; set; }
        public decimal Netsum { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Saledocumentposition> Saledocumentposition { get; set; }
    }
}
