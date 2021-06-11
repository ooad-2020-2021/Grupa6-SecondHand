using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum AccessoriesCategory
    {
        [Display(Name = "Hat")]
        Hat,
        [Display(Name = "Scarf")]
        Scarf,
        [Display(Name = "Bag")]
        Bag,
        [Display(Name = "Jewelery")]
        Jewelery,
        [Display(Name = "Wallet")]
        Wallet,
        [Display(Name = "Glasses")]
        Glasses,
        [Display(Name = "Belt")]
        Belt,
        [Display(Name = "Watch")]
        Watch
    }
}
