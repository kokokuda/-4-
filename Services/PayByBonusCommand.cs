using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    public class PayByBonusCommand: ICommand
    {
        private readonly Buyer buyer;
        private readonly decimal amount;

        public PayByBonusCommand(Buyer buyer, decimal amount)
        {
            this.buyer = buyer;
            this.amount = amount;
        }

        public void Execute()
        {
            if (buyer.BonusPoints < amount)
                throw new InvalidOperationException("Недостаточно бонусных средств");

            buyer.DeductBonusPoints(amount);
        }
    }
}
