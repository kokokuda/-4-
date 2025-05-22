using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace MyShop.Models
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items => items.AsReadOnly();

        public void AddProduct(Product product, decimal weight = 1)
        {
            items.Add(new CartItem(product, weight));
        }

        public void RemoveProduct(CartItem item)
        {
            items.Remove(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public decimal GetTotalPrice()
        {
            return items.Sum(item => item.TotalPrice);
        }
    }
}
