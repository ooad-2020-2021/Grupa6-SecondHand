using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Transactions
    {
        [Key]
        [DisplayName("Id:")]
        public int id { get; set; }
        
        [Required]
        [DisplayName("Product Id:")]
        public Product Product { get; set; }

        [Required]
        [DisplayName("Buyer Id:")]
        public IdentityUser Buyer { get; set; }
        /*
        [Required]
        [DisplayName("Seler Id:")]
        public IdentityUser Seler { get; set; }
        */

        public Transactions()
        {
        }

        public static implicit operator List<object>(Transactions v)
        {
            throw new NotImplementedException();
        }
    }
}
