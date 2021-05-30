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
        [DisplayName("ID:")]
        public int id { get; set; }
        
        [Required]
        [DisplayName("Product ID:")]
        public Product Product { get; set; }

        [Required]
        [DisplayName("Buyer ID:")]
        public User Buyer { get; set; }

        [Required]
        [DisplayName("Seler ID:")]
        public User Seler { get; set; }


        public Transactions()
        {
        }
    }
}
