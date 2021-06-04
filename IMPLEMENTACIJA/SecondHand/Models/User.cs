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

        [DisplayName("Payment information:")]
        public PaymentInformation PaymentInformation { get; set; }

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
