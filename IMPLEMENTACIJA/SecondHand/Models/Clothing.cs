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
        [EnumDataType(typeof(ClothingCategory))]
        [DisplayName("Clothing category:")]
        public ClothingCategory ClothingCategory { get; set; }
        #endregion

        #region Konstruktor
        public Clothing(int iD, 
            string naziv, 
            string description, 
            string image, 
            double price, 
            Color color, 
            Material material, 
            Condition condition, 
            Brand brand, 
            Gender gender, 
            User owner,
            ClothingSize clothingSize,
            ClothingCategory clothingCategory) : 
            base(iD, naziv, description, image, price, color, material, condition, brand, gender, owner)
        {
            ClothingCategory = clothingCategory;
            ClothingSize = clothingSize;
        }
        #endregion




    }
}
