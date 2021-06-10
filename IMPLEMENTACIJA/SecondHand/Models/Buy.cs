using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public string Adresa { get; set; }
        public string Grad { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        [DisplayName("Card number:")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
    ErrorMessage = "Invalid format!")]
        public string BrojKartice { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public string ValidThru { get; set; }
        [Required]
        public int CVV { get; set; }
        public Buy() { }




    }
}
