using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum Brand
    {
        [Display(Name = "Nike")]
        Nike,
        [Display(Name = "Adidas")]
        Adidas,
        [Display(Name = "PullAndBear")]
        PullAndBear,
        [Display(Name = "Zara")]
        Zara,
        [Display(Name = "Stradivarius")]
        Stradivarius,
        [Display(Name = "Gucci")]
        Gucci,
        [Display(Name = "Rolex")]
        Rolex,
        [Display(Name = "Unknown")]
        Unknown

    }
}
