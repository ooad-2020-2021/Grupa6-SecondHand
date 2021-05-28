using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public List<Product> Products = new List<Product>();

        public Cart()
        {
        }
    }
}
