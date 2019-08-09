namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Common;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;

    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
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

        public override string ToString()
        {
            return $"{Name}: {this.ServingSize}g - {this.Price:F2}";
        }
    }
}