 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Models;
using MyShop.Views;

namespace MyShop.Presenters
{
    public class BuyerSettingsPresenter
    {
        private readonly IBuyerSettingsView view;
        private readonly Buyer buyer;

        public BuyerSettingsPresenter(IBuyerSettingsView view, Buyer buyer)
        {
            this.view = view;
            this.buyer = buyer;

            // Подписываемся на событие кнопки Применить
            this.view.ApplyClicked += OnApplyClicked;
        }

        private void OnApplyClicked(object sender, EventArgs e)

        {
            // Считываем новые значения с формы
            decimal newCash = view.CashAmount;
            decimal newCard = view.CardAmount;
            decimal newBonus = view.BonusAmount;

            // Обновляем данные покупателя
            buyer.UpdateBalances(newCash, newCard, newBonus);

            // Закрываем форму настроек
            view.CloseForm();
        }
    }
}
