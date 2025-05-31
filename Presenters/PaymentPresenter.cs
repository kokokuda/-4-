using MyShop.Models;
using MyShop.Services;
using System;

namespace MyShop.Presenters
{
    public class PaymentPresenter
    {
        private readonly Buyer buyer; // Покупатель
        private readonly PaymentCommandInvoker invoker = new PaymentCommandInvoker(); // Инвокер для хранения и выполнения команд
        private decimal remainingAmountToPay; // Сколько осталось оплатить

        public decimal RemainingAmountToPay => remainingAmountToPay;

        // Событие при изменении остатка оплаты
        public event Action<decimal> PaymentProgressChanged;

        // Событие при успешной полной оплате
        public event Action PaymentCompleted;

        // Событие при ошибке (например, недостаточно средств)
        public event Action<string> PaymentFailed;

        public PaymentPresenter(Buyer buyer)
        {
            this.buyer = buyer ?? throw new ArgumentNullException(nameof(buyer));
        }

        // Устанавливает сумму, которую нужно оплатить
        public void StartPayment(decimal totalAmount)
        {
            if (totalAmount <= 0)
                throw new ArgumentException("Сумма оплаты должна быть больше нуля.");

            remainingAmountToPay = totalAmount;
            invoker.ClearCommands(); // Очищаем предыдущие команды
        }

        // Оплата наличными
        public void PayByCash(decimal amount)
        {
            TryExecuteCommand(new PayByCashCommand(buyer, amount), amount);
        }

        // Оплата с карты
        public void PayByCard(decimal amount)
        {
            TryExecuteCommand(new PayByCardCommand(buyer, amount), amount);
        }

        // Оплата бонусами
        public void PayByBonus(decimal amount)
        {
            TryExecuteCommand(new PayByBonusCommand(buyer, amount), amount);
        }

        // Проверка и выполнение команды
        private void TryExecuteCommand(ICommand command, decimal amount)
        {
            if (amount <= 0)
            {
                PaymentFailed?.Invoke("Сумма должна быть больше нуля.");
                return;
            }

            if (amount > remainingAmountToPay)
            {
                PaymentFailed?.Invoke("Сумма оплаты не может превышать оставшуюся сумму.");
                return;
            }

            try
            {
                invoker.AddCommand(command); // Добавляем команду
                command.Execute();           // Выполняем команду
                remainingAmountToPay -= amount;
                PaymentProgressChanged?.Invoke(remainingAmountToPay);
                CheckCompletion();          // Проверка: не завершена ли оплата
            }
            catch (InvalidOperationException ex)
            {
                PaymentFailed?.Invoke(ex.Message);
            }
        }

        // Проверяет, оплачена ли вся сумма
        private void CheckCompletion()
        {
            if (remainingAmountToPay == 0)
            {
                PaymentCompleted?.Invoke();
            }
        }
    }
}
