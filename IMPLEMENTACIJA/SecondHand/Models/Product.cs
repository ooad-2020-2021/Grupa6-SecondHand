using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public abstract class Product
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Color Color { get; set; }
        public Material Material { get; set; }
        public Condition Condition { get; set; }
        public Brand Brand { get; set; }

        
    }
}
