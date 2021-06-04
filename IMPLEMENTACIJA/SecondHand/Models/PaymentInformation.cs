using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class PaymentInformation
    {
        [Key]
        [DisplayName("Id:")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Full name:")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Card number:")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
            ErrorMessage = "Neispravan format card number!")]
        public string CardNumber { get; set; }

        [Required]
        [DisplayName("Valid thru:")]
        public string ValidThru { get; set; }

        [Required]
        [DisplayName("CVV:")]
        public string CVV { get; set; }

        public PaymentInformation(string fullName, string cardNumber, string validThru, string cVV)
        {
            FullName = fullName;
            CardNumber = cardNumber;
            ValidThru = validThru;
            CVV = cVV;
        }
    }
}
