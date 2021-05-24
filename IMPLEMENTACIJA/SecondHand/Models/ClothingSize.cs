using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum ClothingSize
    {
        [Display(Name = "XS")]
        XS,
        [Display(Name = "S")]
        S,
        [Display(Name = "M")]
        M,
        [Display(Name = "L")]
        L,
        [Display(Name = "XL")]
        XL,
        [Display(Name = "Undefined")]
        Undefined
    }
}
