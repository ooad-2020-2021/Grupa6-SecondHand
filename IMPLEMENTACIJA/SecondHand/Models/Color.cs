using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum Color
    {
        [Display(Name = "Red")]
        Red,
        [Display(Name = "Blue")]
        Blue,
        [Display(Name = "Yellow")]
        Yellow,
        [Display(Name = "Green")]
        Green,
        [Display(Name = "White")]
        White,
        [Display(Name = "Black")]
        Black,
        [Display(Name = "Purple")]
        Purple,
        [Display(Name = "Brown")]
        Brown

    }
}
