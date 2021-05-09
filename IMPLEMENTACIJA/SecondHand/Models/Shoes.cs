using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Shoes
    {
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
