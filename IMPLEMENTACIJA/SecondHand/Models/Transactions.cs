using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Transactions
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public Product Product { get; set; }

        [Required]
        public User Buyer { get; set; }

        [Required]
        public User Seler { get; set; }


        public Transactions()
        {
        }
    }
}
