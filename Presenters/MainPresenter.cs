using MyShop.Services;
using MyShop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;

        public MainPresenter(IMainView view)
        {
            this.view = view;
        }

        // Метод, который загружает продукты и передает их форме для отображения
        public void LoadProducts()
        {
            var products = ProductFactory.LoadProducts("products.json");
            view.DisplayProducts(products);
        }
    }
}
