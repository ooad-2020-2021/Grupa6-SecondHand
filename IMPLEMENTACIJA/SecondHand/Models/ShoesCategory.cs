using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum ShoesCategory
    {
        [Display(Name = "Boots")]
        Boots,
        [Display(Name = "Slippers")]
        Slippers,
        [Display(Name = "Sandals")]
        Sandals,
        [Display(Name = "Heels")]
        Heels,
        [Display(Name = "RunningShoes")]
        RunningShoes,
        [Display(Name = "Shoes")]
        Shoes
    }
}
