using Microsoft.AspNetCore.Identity;
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
        [DisplayName("Id:")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Rating:")]
        public int Rating { get; set; }

        [Required]
        [DisplayName("Owner:")]
        public IdentityUser Owner { get; set; }

        [Required]
        [DisplayName("Review user:")]
        public IdentityUser ReviewedUser { get; set; }

        public Review()
        {
            
        }
    }
}
