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
        public User Buyer { get; set; }

        [Required]
        [DisplayName("Seler Id:")]
        public User Seler { get; set; }


        public Transactions()
        {
        }
    }
}
