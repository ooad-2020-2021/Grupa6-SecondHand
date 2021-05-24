using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class User
    {
        private string _email;
        private DateTime _birthday;
        private DateTime _joiningDate;
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        [Key]
        [Required]
        public int ID { get; set; } //generisati

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email {
            get
            {
                return _email;
            }
            set {
                if (IsValidEmail(_email))
                    _email = value;
            } }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if ((DateTime.Now - value).TotalDays > 6570)
                {
                    _birthday = value;
                }
            }
        }

        [Required]
        public DateTime JoiningDate { get => _joiningDate;
            set { _joiningDate = DateTime.Now; }
        }

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
