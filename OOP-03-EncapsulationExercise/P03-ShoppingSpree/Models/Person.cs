namespace ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (product.Cost > this.money)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.money -= product.Cost;
            products.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            if (this.products.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.products)}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}