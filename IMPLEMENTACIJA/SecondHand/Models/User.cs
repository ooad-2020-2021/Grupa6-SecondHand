using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class User
    {

        private DateTime _birthday;
        private DateTime _joiningDate;

        [Key]
        [Required]
        [DisplayName("Id:")]
        public int ID { get; set; } //generisati

        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Username:")]
        public string Username { get; set; }

        [Required]
        [DisplayName("E-mail:")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage = "Neispravan format za E-mail!")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password:")]
        public string Password { get; set; }

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
        [DisplayName("Payment information:")]
        public PaymentInformation PaymentInformation { get; set; }

        [DisplayName("User rating:")]
        public double UserRating { get; set; }


        [NotMapped]
        public List<Product> Products { get; set; }

        public User(int iD, string name, string username, string email, string password, DateTime birthday, DateTime joiningDate, string adress, Gender gender, string profilePicture)
        {
            ID = iD;
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            Birthday = birthday;
            JoiningDate = joiningDate;
            Adress = adress;
            Gender = gender;
            ProfilePicture = profilePicture;
            Cart = new Cart();
            //PaymentInformation = new PaymentInformation(fullName, cardNumber, validThru, cVV);
            UserRating = 0;

            Products = new List<Product>();

        }
    }
}
