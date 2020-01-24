using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class AllDocuments
    {
        public int Documentid { get; set; }
        public string Documentnumber { get; set; }
        public int Contractorid { get; set; }
        public int Userid { get; set; }
        public DateTime Moddate { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Invoicedate { get; set; }
        public decimal Grosssum { get; set; }
        public decimal Netsum { get; set; }
    }
}
