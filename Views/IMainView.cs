using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Views
{
    public interface IMainView
    {
        // Метод, который Presenter будет вызывать, чтобы показать список продуктов на форме
        void DisplayProducts(List<Product> products);
    }
}
