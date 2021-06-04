using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Clothing : Product
    {
        #region Properties
       

        [Required]
        public ClothingSize ClothingSize { get; set; }

        [Required]
        [EnumDataType(typeof(AccessoriesChategory))]
        [DisplayName("Clothing category:")]
        public AccessoriesChategory ClothingCategory { get; set; }
        #endregion

        #region Konstruktor
        public Clothing( ) : 
            base()
        {
        }
        #endregion




    }
}
