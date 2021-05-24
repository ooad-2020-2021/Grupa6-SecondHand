using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum Gender
    {
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Male")]
        Male
    }
}
