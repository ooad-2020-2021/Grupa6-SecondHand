using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public abstract class Product
    {
        #region Properties
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public double Price { get; set; }

        public Color Color { get; set; }
        public Material Material { get; set; }
        public Condition Condition { get; set; }
        public Brand Brand { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public User Owner { get; set; }

        #endregion

        #region Konstruktor

        protected Product(int iD, string naziv, 
            string description, 
            string image, 
            double price, 
            Color color, 
            Material material, 
            Condition condition, 
            Brand brand, 
            Gender gender, 
            User owner)
        {
            ID = iD;
            Naziv = naziv;
            Description = description;
            Image = image;
            Price = price;
            Color = color;
            Material = material;
            Condition = condition;
            Brand = brand;
            Gender = gender;
            Owner = owner;
        }

        #endregion
    }
}
