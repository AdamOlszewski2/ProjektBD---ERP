﻿using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Invoicedocumentposition
    {
        public int Invoicedocumentpositionid { get; set; }
        public int Documentid { get; set; }
        public int Productid { get; set; }
        public byte Vatrateid { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Netsum { get; set; }
        public decimal Grosssum { get; set; }
        public int Quantity { get; set; }

        public virtual Invoicedocument Document { get; set; }
        public virtual Product Product { get; set; }
        public virtual Vatrate Vatrate { get; set; }
    }
}
