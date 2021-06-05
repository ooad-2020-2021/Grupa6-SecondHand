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
        [EnumDataType(typeof(AccessoriesCategory))]
        [DisplayName("Accessorie category:")]
        public AccessoriesCategory AccessoriesChategory { get; set; }

        public Accessories()
        {
        }
    }
}

