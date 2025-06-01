using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Services
{
    public class PayByCardCommand : ICommand
    {
        private readonly Buyer buyer; 
        private readonly decimal amount; 

        public PayByCardCommand(Buyer buyer, decimal amount)
        {
            this.buyer = buyer;
            this.amount = amount;
        }

        public void Execute()
        {
            if (buyer.Card < amount)
                throw new InvalidOperationException("Недостаточно безналичных средств");

            buyer.DeductFromCard(amount); 
        }
    }
}
