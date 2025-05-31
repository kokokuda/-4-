using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public decimal Weight { get; set; } = 1;

        public decimal TotalPrice => Product.Price * Weight;

        public CartItem(Product product, decimal weight = 1)
        {
            Product = product;
            Weight = weight;
        }
    }
}
