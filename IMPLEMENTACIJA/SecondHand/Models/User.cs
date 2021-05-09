using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Adress { get; set; }
        public Gender Gender { get; set; }
        public string ProfilePicture { get; set; }
        public Cart Cart { get; set; }
        public UserProducts UserProducts { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
        public double UserRating { get; set; }
    }
}
