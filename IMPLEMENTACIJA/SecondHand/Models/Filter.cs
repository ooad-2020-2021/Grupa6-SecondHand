using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    [Keyless]
    public class Filter
    {
        
        public int ID;
        public int AccessoriesCategory;
        public int Brand;
        public int ClozhingCategory;
        public int ClothingSize;
        public int Color;
        public int Condition;
        public int Gender;
        public int Material;
        public int ShoesCategory;
    }
}
