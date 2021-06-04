using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Accessories : Product
    {


        [Required]
        [EnumDataType(typeof(AccessoriesChategory))]
        [DisplayName("Accessorie category:")]
        public AccessoriesChategory AccessoriesChategory { get; set; }

        public Accessories()
        {
        }
    }
}

