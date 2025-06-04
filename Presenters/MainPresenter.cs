using MyShop.Models;
using MyShop.Services;
using MyShop.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView view;

        public Buyer Buyer { get; private set; }
        public List<Product> Products { get; private set; }

        public string ProductFilePath { get; } = "products.json";

        // Общая сумма к оплате (из корзины) и сколько уже оплачено
        private decimal totalToPay = 0;
        private decimal alreadyPaid = 0;

        public MainPresenter(IMainView view)
        {
            this.view = view;

            // Создаём покупателя с пустым кошельком и корзиной
            Buyer = new Buyer(0m, 0m, 0m, new Cart());

            // Подписка на событие "Открыть настройки"
            view.OpenSettingsClicked += OnOpenSettingsClicked;

            // Подписка на изменение суммы, введённой пользователем
            view.AmountChanged += OnAmountChanged;

            // Показываем балансы на старте
            UpdateViewBalances();
        }

        // Загрузка товаров из файла и отображение их во View
        public void LoadProducts()
        {
            Products = ProductFactory.LoadProducts(ProductFilePath);
            view.DisplayProducts(Products);

            // Обновим сумму к оплате при загрузке товаров (если уже есть корзина)
            UpdateTotalToPayFromCart();
        }

        // Получить сумму из корзины и обновить переменные
        public void UpdateTotalToPayFromCart()
        {
            // Пересчитываем общую сумму по корзине
            totalToPay = Buyer.Cart.GetTotalPrice();

            // Остаток = сколько ещё нужно доплатить
            decimal remaining = Math.Max(0, totalToPay - alreadyPaid);

            view.UpdateRemaining(remaining);

            // Обновляем отображение корзины и итога
            view.DisplayCartItems(Buyer.Cart.Items);
            view.DisplayTotal(totalToPay);

            // Если оплачено уже больше или равно — завершить заказ
            if (IsPaymentComplete())
            {
                Buyer.Cart.Clear();
                alreadyPaid = 0;
                totalToPay = 0;

                view.DisplayCartItems(Buyer.Cart.Items);
                view.DisplayTotal(0);
                view.UpdateRemaining(0);
                view.UpdateStatus("Оплата завершена");
            }
            else
            {
                view.UpdateStatus("");
            }

            // Показываем сообщение, если денег не хватает
            CheckEnoughMoney();
        }

        // Выполнение команды оплаты и обновление оставшейся суммы
        public void ExecuteCommand(ICommand command, decimal amount)
        {
            decimal remaining = Math.Max(0, totalToPay - alreadyPaid); // сколько осталось оплатить 
            decimal amountToUse = Math.Min(amount, remaining); // сколько спишем с покупателя

            // Заменяем команду на новую с корректной суммой
            if (command is PayByCashCommand)
            {
                command = new PayByCashCommand(Buyer, amountToUse);
            }
            else if (command is PayByCardCommand)
            {
                command = new PayByCardCommand(Buyer, amountToUse);
            }
            else if (command is PayByBonusCommand)
            {
                command = new PayByBonusCommand(Buyer, amountToUse);
            }
            else
            {
                throw new InvalidOperationException("Неизвестная команда оплаты.");
            }

            command.Execute();
            alreadyPaid += amountToUse;

            view.UpdateRemaining(totalToPay - alreadyPaid);
            UpdateViewBalances();

            if (IsPaymentComplete())
            {
                DeductFromStock();
                view.DisplayProducts(Products);

                Buyer.Cart.Clear();
                alreadyPaid = 0;
                totalToPay = 0;

                view.DisplayCartItems(Buyer.Cart.Items);
                view.DisplayTotal(0);
                view.UpdateRemaining(0);
                view.UpdateStatus("Оплата завершена");
            }
            else
            {
                view.UpdateStatus("");
            }
        }

        // Обработка нажатия на кнопку "Настройки покупателя"
        private void OnOpenSettingsClicked(object sender, EventArgs e)
        {
            var settingsForm = new BuyerSettingsForm();
            var settingsPresenter = new BuyerSettingsPresenter(settingsForm, Buyer);
            settingsForm.ShowDialog();

            // Обновляем балансы после закрытия формы настроек
            UpdateViewBalances();

        }

        // Показываем текущие балансы покупателя на форме
        private void UpdateViewBalances()
        {
            view.UpdateBalances(Buyer.Cash, Buyer.Card, Buyer.BonusPoints);

            decimal total = Buyer.Cash + Buyer.Card + Buyer.BonusPoints;
            view.UpdateTotalBalance(total);
        }

        // Событие при вводе суммы оплаты вручную — просто показать текущий остаток (не учитывать как оплату)
        private void OnAmountChanged(object sender, EventArgs e)
        {
            decimal entered = GetAmountFromView();
            decimal remaining = Math.Max(0, totalToPay - alreadyPaid - entered);
            view.UpdateRemaining(remaining);
        }

        // Получаем сумму, введённую пользователем
        private decimal GetAmountFromView()
        {
            if (decimal.TryParse(view.GetEnteredAmount(), out var amount))
                return amount;
            return 0;
        }

        private bool IsPaymentComplete()
        {
            return totalToPay > 0 && alreadyPaid >= totalToPay;
        }

        // метод проверки баланса
        public void CheckEnoughMoney()
        {
            var total = Buyer.Cart.GetTotalPrice();
            var allBalance = Buyer.Cash + Buyer.Card + Buyer.BonusPoints;

            bool notEnough = total > 0 && allBalance < total;

            view.LockPaymentButtons(notEnough); // true = заблокировать

            if (notEnough)
            {
                view.ShowLowBalanceWarning();
            }
        }

        private void DeductFromStock()
        {
            foreach (var item in Buyer.Cart.Items)
            {
                var matchingProduct = Products.FirstOrDefault(p => p.Name == item.Product.Name);

                if (matchingProduct != null)
                {
                    // Если товар весовой
                    if (matchingProduct is WeightedProduct)
                    {
                        matchingProduct.Quantity -= item.Weight; // item.Weight — вес, введённый пользователем
                    }
                    else
                    {
                        matchingProduct.Quantity -= 1; // обычный товар — количество поштучно
                    }

                    if (matchingProduct.Quantity < 0)
                        matchingProduct.Quantity = 0;
                }
            }


           

            // Сохраняем обратно в файл
            ProductFactory.SaveProducts(ProductFilePath, Products);
        }
    }
}
