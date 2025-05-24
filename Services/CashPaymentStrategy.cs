using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Models;

namespace MyShop.Services
{
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public string Name => "Наличные";

        public bool Pay(Buyer buyer, decimal amount)
        {
            if (buyer.Cash >= amount)
            {
                buyer.DeductCash(amount);
                return true;
            }
            return false;
        }
    }
}
