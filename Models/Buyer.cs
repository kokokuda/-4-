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

        public Buyer(decimal cash, decimal card, decimal bonusPoints, Cart cart)
        {
            Cash = cash;
            Card = card;
            BonusPoints = bonusPoints;
            Cart = cart;
        }

        // Методы уменьшения балансов
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

        // Обновление баланса (опционально)
        public void UpdateBalances(decimal cash, decimal card, decimal bonus)
        {
            Cash = cash;
            Card = card;
            BonusPoints = bonus;
        }

        public decimal TotalBalance => Cash + Card + BonusPoints;
    }
}