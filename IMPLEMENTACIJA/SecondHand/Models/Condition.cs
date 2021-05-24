using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public enum Condition
    {
        [Display(Name = "Unused")]
        Unused,
        [Display(Name = "LikeNew")]
        LikeNew,
        [Display(Name = "Used")]
        Used,
        [Display(Name = "WornOut")]
        WornOut
    }
}
