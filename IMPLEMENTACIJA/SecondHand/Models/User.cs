using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public Gender Gender { get; set; }


        public string ProfilePicture { get; set; }
        public Cart Cart { get; set; }
        public UserProducts UserProducts { get; set; }

        [Required]
        public PaymentInformation PaymentInformation { get; set; }
        public double UserRating { get; set; }
    }
}
