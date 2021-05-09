using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Clothing : Product
    {
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

        public ClothingSize ClothingSize { get; set; }
        public ClothingCategory ClothingCategory { get; set; }


    }
}
