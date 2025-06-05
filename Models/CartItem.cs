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

        public decimal Weight { get; set; } = 0; // Только для весовых
        public int Quantity { get; set; } = 0;   // Только для штучных

        public decimal TotalPrice
        {
            get
            {
                if (Product is WeightedProduct)
                    return Product.Price * Weight;
                else
                    return Product.Price * Quantity;
            }
        }

        public CartItem(Product product, decimal weight = 0, int quantity = 0)
        {
            Product = product;
            Weight = weight;
            Quantity = quantity;
        }
    }
}
