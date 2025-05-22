using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MyShop.Services
{
    public static class ProductFactory
    {
        public static List<Product> LoadProducts(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var rawProducts = JsonConvert.DeserializeObject<List<RawProduct>>(json);

            var result = new List<Product>();
            foreach (var item in rawProducts)
            {
                ProductType type = item.Type == "Weighted" ? ProductType.Weighted : ProductType.Simple;
                result.Add(new Product { Name = item.Name, Price = item.Price, Type = type });
            }

            return result;
        }

        private class RawProduct
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Type { get; set; }
        }
    }
}
