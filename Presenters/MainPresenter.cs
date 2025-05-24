using MyShop.Models;
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

        // Модель покупателя, храним его текущие балансы и корзину
        private Buyer buyer;

        public MainPresenter(IMainView view)
        {
            this.view = view;

            // Инициализируем покупателя с нулевыми балансами и пустой корзиной
            buyer = new Buyer(0m, 0m, 0m, new Cart());

            // Подписываемся на событие "Открыть настройки"
            this.view.OpenSettingsClicked += OnOpenSettingsClicked;

            // При старте обновляем отображение баланса
            UpdateViewBalances();
        }

        // Метод загрузки продуктов из файла и отображения их во вью
        public void LoadProducts()
        {
            var products = ProductFactory.LoadProducts("products.json");
            view.DisplayProducts(products);
        }

        // Метод для отображения актуального состояния баланса на главной форме
        private void UpdateViewBalances()
        {
            view.UpdateBalances(buyer.Cash, buyer.Card, buyer.BonusPoints);
        }

        // Обработчик клика по кнопке "Настройки"
        private void OnOpenSettingsClicked(object sender, EventArgs e)
        {
            // Создаем форму настроек покупателя
            var settingsForm = new BuyerSettingsForm();

            // Создаем презентер для настроек, передаём ему форму и покупателя
            var settingsPresenter = new BuyerSettingsPresenter(settingsForm, buyer);

            // Показываем форму настроек как модальное окно
            settingsForm.ShowDialog();

            // После закрытия формы обновляем отображение баланса
            UpdateViewBalances();
        }
    }
}
