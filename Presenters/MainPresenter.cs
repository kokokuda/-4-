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

            // Обновим отображение баланса при старте
            UpdateViewBalances();

            view.AmountChanged += OnAmountChanged; // обновления остатка к оплате
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
            var settingsForm = new BuyerSettingsForm();
            var settingsPresenter = new BuyerSettingsPresenter(settingsForm, Buyer);
            settingsForm.ShowDialog();

            // Обновим баланс после изменения
            UpdateViewBalances();
        }

        // Метод выполнения команды оплаты
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();            // Выполняем действие
            UpdateViewBalances();         // Обновляем отображение
        }


        private void OnAmountChanged(object sender, EventArgs e)
        {
            decimal total = GetCartTotal(); // Получи сумму из корзины
            decimal entered = GetAmountFromView(); // Сумма, которую ввел пользователь
            decimal remaining = Math.Max(0, total - entered);
            view.UpdateRemaining(remaining);
        }


        private decimal GetCartTotal()
        {
            return Buyer.Cart.GetTotalPrice(); 
        }

        private decimal GetAmountFromView()
        {
            if (decimal.TryParse(view.GetEnteredAmount(), out var amount))
                return amount;
            return 0;
        }



        /// <summary>
        /// ///////////////
        /// </summary>
        private decimal remainingAmount;

        public void InitializeRemainingAmount(decimal total)
        {
            remainingAmount = total;
            view.UpdateRemaining(remainingAmount);
        }
    }
}
