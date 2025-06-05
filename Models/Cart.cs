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
            var existingItem = items.FirstOrDefault(i => i.Product == product);

            if (product is WeightedProduct)
            {
                decimal alreadyInCart = existingItem?.Weight ?? 0;
                decimal totalRequested = alreadyInCart + weight;

                if (totalRequested > product.Quantity)
                    throw new InvalidOperationException("Нельзя добавить больше, чем есть на складе");

                if (existingItem != null)
                    existingItem.Weight += weight;
                else
                    items.Add(new CartItem(product, weight: weight));
            }
            else // штучный товар
            {
                int currentQuantity = existingItem?.Quantity ?? 0;
                int requestedQuantity = currentQuantity + (int)weight;

                if (requestedQuantity > product.Quantity)
                    throw new InvalidOperationException("Нельзя добавить больше, чем есть на складе");

                if (existingItem != null)
                    existingItem.Quantity += (int)weight;
                else
                    items.Add(new CartItem(product, quantity: (int)weight));
            }
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

        public bool IsEmpty()
        {
            return !items.Any(); //  true - если корзина пуста
        }



        public decimal TotalPrice => GetTotalPrice();
    }
}
