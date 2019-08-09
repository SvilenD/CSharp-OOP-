namespace SoftUniRestaurant.Models.Drinks
{
    using System;
    using SoftUniRestaurant.Common;
    using SoftUniRestaurant.Models.Drinks.Contracts;

    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NULL_Name);
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get
            {
                return this.servingSize;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NEGATIVE_ServingSize);
                }

                this.servingSize = value;
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
                    throw new ArgumentException(ExceptionMessages.NEGATIVE_Price);
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NULL_BrandName);
                }

                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}