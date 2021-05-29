using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Shoes : Product
    {
        #region Properties
      

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

        [EnumDataType(typeof(ShoesCategory))]
        [DisplayName("Shoe Category:")]
        public ShoesCategory ShoesCategory { get; set; }

        #endregion

        #region Konstruktor

        public Shoes() :
            base()
        {
        }

        #endregion
    }
}
