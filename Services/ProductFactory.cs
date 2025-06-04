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
                    if (item.Type == "Weighted")
                    {
                        var weightedProduct = new WeightedProduct
                        {
                            Name = item.Name,
                            Price = item.Price,
                            Weight = 0,
                            Quantity = item.Quantity
                        };
                        result.Add(weightedProduct);
                    }
                    else
                    {
                        var product = new Product
                        {
                            Name = item.Name,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };
                        result.Add(product);
                    }
                }

                return result;
            }

            public static void SaveProducts(string filePath, List<Product> products)
            {
                var rawProducts = products.Select(p => new RawProduct
                {
                    Name = p.Name,
                    Price = p.Price,
                    Type = p is WeightedProduct ? "Weighted" : "Simple",
                    Quantity = p.Quantity
                }).ToList();

                var json = JsonConvert.SerializeObject(rawProducts, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }

            private class RawProduct
            {
                public string Name { get; set; }
                public decimal Price { get; set; }
                public string Type { get; set; }
                public decimal Quantity { get; set; }
            }
        }
    }
