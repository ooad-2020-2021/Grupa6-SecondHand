using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Review
    {
        [Key]
        [DisplayName("ID:")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Rating:")]
        public int Rating { get; set; }

        [Required]
        [DisplayName("Owner:")]
        public User Owner { get; set; }

        [Required]
        [DisplayName("Review user:")]
        public User ReviewedUser { get; set; }

        public Review()
        {
            
        }
    }
}
