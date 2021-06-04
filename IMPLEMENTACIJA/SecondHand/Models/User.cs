using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class User : IdentityUser
    {

        private DateTime _birthday;
        private DateTime _joiningDate;

        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birthday:")]
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
        [DataType(DataType.Date)]
        [DisplayName("Joining date:")]
        public DateTime JoiningDate { get => _joiningDate;
            set { _joiningDate = DateTime.Now; }
        }

        [Required]
        [DisplayName("Adress:")]
        public string Adress { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        [DisplayName("Gender:")]
        public Gender Gender { get; set; }

        [DisplayName("ProfilePictureID:")]
        public string ProfilePicture { get; set; }

        [DisplayName("Cart:")]
        public Cart Cart { get; set; }

        [Required]
        [DisplayName("Full name:")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Card number:")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$",
            ErrorMessage = "Neispravan format card number!")]
        public string CardNumber { get; set; }

        [Required]
        [DisplayName("Valid thru:")]
        public string ValidThru { get; set; }

        [Required]
        [DisplayName("CVV:")]
        public string CVV { get; set; }

        [DisplayName("User rating:")]
        public double UserRating { get; set; }

        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }
        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
        public override bool TwoFactorEnabled { get => base.TwoFactorEnabled; set => base.TwoFactorEnabled = value; }
        public override DateTimeOffset? LockoutEnd { get => base.LockoutEnd; set => base.LockoutEnd = value; }
        public override bool LockoutEnabled { get => base.LockoutEnabled; set => base.LockoutEnabled = value; }
        public override int AccessFailedCount { get => base.AccessFailedCount; set => base.AccessFailedCount = value; }

        public User ()
        {

        }

        public User(string userName) : base(userName)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
