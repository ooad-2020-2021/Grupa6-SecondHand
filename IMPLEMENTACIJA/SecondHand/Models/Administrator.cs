using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Administrator
    {
        [Key]
        [DisplayName("Id:")]
        public int ID { get; set; }

        [Required]
        [DisplayName("E-mail:")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", 
            ErrorMessage = "Neispravan format za E-mail!")]
        public string Email { get; set; }

        [Required]
        [DisplayName("PasswordHash:")]
        public string Passwrod { get; set; }

        public Administrator()
        {
        }
    }
}
