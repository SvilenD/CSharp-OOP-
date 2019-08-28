using INStock.Contracts;
using System;
using System.Linq;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get
            {
                return this.label;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid label.");
                }

                this.label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price should have a positive value");
                }

                this.price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity should be positive.");
                }

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Label.Sum(c => c).CompareTo(other.Label.Sum(c => c));
        }
    }
}