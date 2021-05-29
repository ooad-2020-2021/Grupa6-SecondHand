using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public User Owner { get; set; }

        [Required]
        public User ReviewedUser { get; set; }

        public Review()
        {
            
        }
    }
}
