using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Accessories : Product
    {
        
        public AccessoriesCategory AccessoriesCategory { get; set; }

        public Accessories(int iD, 
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
            AccessoriesCategory accessoriesCategory) : 
            base(iD, naziv, description, image, price, color, material, condition, brand, gender, owner)
        {
            AccessoriesCategory = accessoriesCategory;
        }

        

        
    }
}
