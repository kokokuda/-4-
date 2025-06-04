using System;
using System.Collections.Generic;
using MyShop.Models;

namespace MyShop.Views
{
    public interface IMainView
    {
        // Отобразить список продуктов на форме
        void DisplayProducts(List<Product> products);

        // Событие — пользователь открыл настройки (баланс и т.п.)
        event EventHandler OpenSettingsClicked;

        // Обновить балансы наличных, карты и бонусов на форме
        void UpdateBalances(decimal cash, decimal card, decimal bonus);
        // метод вывести общий баланс
        void UpdateTotalBalance(decimal totalBalance);

        // Обновить оставшуюся к оплате сумму (labelRemaining)
        void UpdateRemaining(decimal remaining);

        // Событие — сумма оплаты в текстбоксе изменилась
        event EventHandler AmountChanged;

        // Получить сумму, введённую пользователем (из текстбокса)
        string GetEnteredAmount();

        void UpdateStatus(string message);
        void LockPaymentButtons(bool locked);

        void DisplayCartItems(IReadOnlyList<CartItem> items);
        void DisplayTotal(decimal total);

        void ShowLowBalanceWarning();
    }
}
