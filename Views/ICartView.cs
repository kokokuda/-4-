using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Views
{
    public interface ICartView
    {
        event Action<Product, decimal> AddProductRequested;
        event Action<CartItem> RemoveProductRequested;
        event Action ClearCartRequested;

        void DisplayCartItems(IReadOnlyList<CartItem> items);
        void DisplayTotal(decimal totalPrice);
    }
}
