using System;
using System.Collections.Generic;

namespace RazorBD.Models
{
    public partial class Users
    {
        public Users()
        {
            Invoicedocument = new HashSet<Invoicedocument>();
            Saledocument = new HashSet<Saledocument>();
        }

        public int Userid { get; set; }
        public string Login { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] Password { get; set; }
        public short Departamentid { get; set; }

        public virtual Departament Departament { get; set; }
        public virtual ICollection<Invoicedocument> Invoicedocument { get; set; }
        public virtual ICollection<Saledocument> Saledocument { get; set; }
    }
}
