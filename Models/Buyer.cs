using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Services;

namespace MyShop.Models
{
    public class Buyer
    {
        // Баланс наличных
        public decimal Cash { get; private set; }

        // Баланс на карте
        public decimal Card { get; private set; }

        // Бонусные баллы
        public decimal BonusPoints { get; private set; }

        public Cart Cart { get; }

        private IPaymentStrategy paymentStrategy;

        public Buyer(decimal cash, decimal card, decimal bonusPoints, Cart cart)
        {
            Cash = cash;
            Card = card;
            BonusPoints = bonusPoints;
            Cart = cart;
        }

        // Установка стратегии оплаты
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            paymentStrategy = strategy;
        }

        /// Пытается оплатить сумму totalPrice с помощью текущей стратегии.
        /// Возвращает true, если оплата прошла успешно, иначе false.
        public bool TryPay(decimal totalPrice)
        {
            if (paymentStrategy == null)
                throw new InvalidOperationException("Payment strategy is not set.");

            return paymentStrategy.Pay(this, totalPrice);
        }

        // Методы уменьшения балансов (вызываются стратегиями)
        public void DeductCash(decimal amount)
        {
            if (amount > Cash)
                throw new InvalidOperationException("Not enough cash.");

            Cash -= amount;
        }

        public void DeductFromCard(decimal amount)
        {
            if (amount > Card)
                throw new InvalidOperationException("Not enough money on card.");

            Card -= amount;
        }

        public void DeductBonusPoints(decimal points)
        {
            if (points > BonusPoints)
                throw new InvalidOperationException("Not enough bonus points.");

            BonusPoints -= points;
        }

        // Методы пополнения балансов
        public void AddToCash(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be positive.");
            Cash += amount;
        }

        public void AddToCard(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Amount must be positive.");
            Card += amount;
        }

        public void AddBonusPoints(decimal points)
        {
            if (points < 0) throw new ArgumentException("Points must be positive.");
            BonusPoints += points;
        }



        // Обновление баланса
        public void UpdateBalances(decimal cash, decimal card, decimal bonus)
        {
            Cash = cash;
            Card = card;
            BonusPoints = bonus;
        }
    }
}
