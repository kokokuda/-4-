using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Models;
using System;
using System.Collections.Generic;


namespace MyShop.Presenters
{
    public class CartPresenter
    {
        private readonly ICartView view;
        private readonly Cart cart;

        public CartPresenter(ICartView view, Cart cart)
        {
            this.view = view;
            this.cart = cart;

            // Подписываемся на события View
            this.view.AddProductRequested += OnAddProductRequested;
            this.view.RemoveProductRequested += OnRemoveProductRequested;
            this.view.ClearCartRequested += OnClearCartRequested;

            UpdateView();
        }

        private void OnAddProductRequested(Product product, decimal weight)
        {
            cart.AddProduct(product, weight);
            UpdateView();
        }

        private void OnRemoveProductRequested(CartItem item)
        {
            cart.RemoveProduct(item);
            UpdateView();
        }

        private void OnClearCartRequested()
        {
            cart.Clear();
            UpdateView();
        }

        private void UpdateView()
        {
            view.DisplayCartItems(cart.Items);
            view.DisplayTotal(cart.GetTotalPrice());
        }
    }

    // Интерфейс View (чтобы Presenter мог с ним работать)
    public interface ICartView
    {
        event Action<Product, decimal> AddProductRequested;
        event Action<CartItem> RemoveProductRequested;
        event Action ClearCartRequested;

        void DisplayCartItems(IReadOnlyList<CartItem> items);
        void DisplayTotal(decimal totalPrice);
    }
}
