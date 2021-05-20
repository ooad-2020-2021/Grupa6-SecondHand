﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Cart
    {
        public class UserProducts
        {

            [NotMapped]
            public List<Product> Products = new List<Product>();

            public UserProducts()
            {
            }

            public void AddProduct(Product product)
            {
                Products.Add(product);
            }
            public void DeleteProduct(Product product)
            {
                Products.Remove(product);
            }
        }
    }
}
