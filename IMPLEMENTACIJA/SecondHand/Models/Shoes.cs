using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Shoes : Product
    {
        public Shoes(int iD,
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
            ShoesCategory shoesCategory,
            int shoesSize) :
            base(iD, naziv, description, image, price, color, material, condition, brand, gender, owner)
        {
            ShoesCategory = shoesCategory;
            ShoeSize = shoesSize;
        }

        private int _shoeSize;
        public int ShoeSize
        {
            get
            {
                return _shoeSize;
            }
            set
            {
                if(value > 33 && value < 47)
                {
                    _shoeSize = value;
                }
            }
        }

        public ShoesCategory ShoesCategory { get; set; }
    }
}
