using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Models;

namespace MyShop.Services
{
    public interface IPaymentStrategy
    {
        bool Pay(Buyer buyer, decimal amount);
        string Name { get; }
    }
}
