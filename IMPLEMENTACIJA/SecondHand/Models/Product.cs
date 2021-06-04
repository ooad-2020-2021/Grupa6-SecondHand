using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Id:")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Name:")]
        public string Naziv { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        [Required]
        [DisplayName("ImageURL:")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Price:")]
        public double Price { get; set; }

        [EnumDataType(typeof(Color))]
        [DisplayName("Color:")]
        public Color Color { get; set; }

        [EnumDataType(typeof(Material))]
        [DisplayName("Material:")]
        public Material Material { get; set; }

        [EnumDataType(typeof(Condition))]
        [DisplayName("Condition:")]
        public Condition Condition { get; set; }

        [EnumDataType(typeof(Brand))]
        [DisplayName("Brand:")]
        public Brand Brand { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        [DisplayName("Gender:")]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("Owner:")]
        public User Owner { get; set; }

        #endregion

        #region Konstruktor

        protected Product()
        {
           
        }

        #endregion
    }
}
