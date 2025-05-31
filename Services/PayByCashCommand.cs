using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    public class PayByCashCommand : ICommand
    {
        private readonly Buyer buyer; // Покупатель, у которого будут списаны наличные
        private readonly decimal amount; // Сумма списания

        public PayByCashCommand(Buyer buyer, decimal amount)
        {
            this.buyer = buyer;
            this.amount = amount;
        }

        public void Execute()
        {
            buyer.DeductCash(amount); // Списание наличных
        }
    }
}
