using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Transactions
    {
        [Required]
        public User User { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}
