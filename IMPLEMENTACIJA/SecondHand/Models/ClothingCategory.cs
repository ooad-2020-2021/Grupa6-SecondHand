using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum ClothingChategory
    {
        [Display(Name = "Hoddie")]
        Hoddie,
        [Display(Name = "Jeans")]
        Jeans,
        [Display(Name = "TShirt")]
        TShirt,
        [Display(Name = "Dress")]
        Dress,
        [Display(Name = "Jacket")]
        Jacket,
        [Display(Name = "Jumper")]
        Jumper,
        [Display(Name = "Skirt")]
        Skirt,
        [Display(Name = "Shorts")]
        Shorts,
        [Display(Name = "Trousers")]
        Trousers
    }
}
