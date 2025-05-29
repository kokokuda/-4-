using System;
using System.Collections.Generic;
using System.Linq;
using MyShop.Models;
using MyShop.Services;
using MyShop.Views;

namespace MyShop.Presenters
{
    public class PaymentPresenter
    {
        private readonly Buyer buyer;
        private readonly List<Product> products;
        private readonly Cart cart;
        private readonly IMainView mainView;
        private readonly ICartView cartView;
        private readonly string productFilePath;

        public PaymentPresenter(Buyer buyer, List<Product> products, Cart cart, IMainView mainView, ICartView cartView, string productFilePath)
        {
            this.buyer = buyer;
            this.products = products;
            this.cart = cart;
            this.mainView = mainView;
            this.cartView = cartView;
            this.productFilePath = productFilePath;
        }

        public void ProcessPayment()
        {
            decimal total = cart.TotalPrice;

            if (!buyer.TryPay(total))
            {
                System.Windows.Forms.MessageBox.Show("Недостаточно средств или неверный способ оплаты.");
                return;
            }

            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Name == item.Product.Name);
                if (product != null)
                {
                    if (product is WeightedProduct)
                        product.Quantity -= item.Weight;
                    else
                        product.Quantity -= 1;
                }
            }

            cart.Clear();

            // Здесь используем методы из нужных интерфейсов:
            cartView.DisplayCartItems(new List<CartItem>());
            cartView.DisplayTotal(0);
            mainView.DisplayProducts(products);


            System.Windows.Forms.MessageBox.Show("Оплата прошла успешно!");
        }
    }
}
