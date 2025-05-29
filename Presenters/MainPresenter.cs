using MyShop.Models;
using MyShop.Services;
using MyShop.Views;
using System;
using System.Collections.Generic;

namespace MyShop.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;

        public Buyer Buyer { get; private set; }
        public List<Product> Products { get; private set; }
        public string ProductFilePath { get; } = "products.json";

        public MainPresenter(IMainView view)
        {
            this.view = view;
            Buyer = new Buyer(0m, 0m, 0m, new Cart());

            view.OpenSettingsClicked += OnOpenSettingsClicked;
            UpdateViewBalances();
        }

        // Метод загрузки продуктов из файла и отображения их во вью
        public void LoadProducts()
        {
            Products = ProductFactory.LoadProducts(ProductFilePath);
            view.DisplayProducts(Products);
        }

        // Метод для отображения актуального состояния баланса на главной форме
        private void UpdateViewBalances()
        {
            view.UpdateBalances(Buyer.Cash, Buyer.Card, Buyer.BonusPoints);
        }

        // Обработчик клика по кнопке "Настройки"
        private void OnOpenSettingsClicked(object sender, EventArgs e)
        {
            // Создаем форму настроек покупателя
            var settingsForm = new BuyerSettingsForm();
            var settingsPresenter = new BuyerSettingsPresenter(settingsForm, Buyer);
            settingsForm.ShowDialog();

            // После закрытия формы обновляем отображение баланса
            UpdateViewBalances();
        }
    }
}
