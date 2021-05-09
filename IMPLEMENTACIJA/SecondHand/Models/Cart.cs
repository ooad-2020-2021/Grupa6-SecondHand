using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Models
{
    public class Cart
    {
        public class UserProducts
        {
            public List<Product> Products = new List<Product>();

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
