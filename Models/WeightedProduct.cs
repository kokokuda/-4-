using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class WeightedProduct : Product
    {
        public decimal Weight { get; set; } // Вес в кг

        public decimal TotalPrice => Price * Weight;
    }
}
