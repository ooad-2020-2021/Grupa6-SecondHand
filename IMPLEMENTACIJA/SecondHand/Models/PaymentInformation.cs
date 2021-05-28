﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class PaymentInformation
    {
        [Key]
        public int Id { get; set; }

        
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public string ValidThru { get; set; }
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
