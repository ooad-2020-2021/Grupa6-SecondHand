using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum Material
    {
        [Display(Name = "Cotton")]
        Cotton,
        [Display(Name = "Polyester")]
        Polyester,
        [Display(Name = "Linen")]
        Linen,
        [Display(Name = "Silk")]
        Silk,
        [Display(Name = "Gold")]
        Gold,
        [Display(Name = "Silver")]
        Silver,
        [Display(Name = "Leather")]
        Lether,
        [Display(Name = "Fur")]
        Fur

    }
}
