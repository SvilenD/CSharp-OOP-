namespace ShoppingSpree.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsList : IEnumerable
    {
        private List<Product> products;

        public ProductsList(params string[] input)
        {
            this.products = GetProducts(input);
        }

        public Product FindProduct(string name)
        {
            return this.products.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var product in this.products)
            {
                yield return product;
            }
        }

        private List<Product> GetProducts(string[] input)
        {
            var products = new List<Product>();

            for (int i = 0; i < input.Length; i++)
            {
                var splittedInfo = input[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = splittedInfo[0];
                var price = decimal.Parse(splittedInfo[1]);

                try
                {
                    products.Add(new Product(name, price));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            return products;
        }
    }
}