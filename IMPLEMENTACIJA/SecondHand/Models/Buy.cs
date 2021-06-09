using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Buy
    {
        [Key]
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Sifra { get; set; }

        public int BrojKartice { get; set; }
        public string ValidThru { get; set; }
        public string CVV { get; set; }
        public Buy() { }




    }
}
