namespace SoftUniRestaurant.Models.Tables
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System.Text;

    public abstract class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders.AsReadOnly();

        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NEGATIVE_TableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.NEGATIVE_NumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var foodsCost = this.foodOrders.Sum(f => f.Price);
            var drinksCost = this.drinkOrders.Sum(d => d.Price);
            return foodsCost + drinksCost + this.Price;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            var info = new StringBuilder();
            info.AppendLine(BaseTableInfo());
            info.AppendLine($"Capacity: {this.Capacity}");
            info.AppendLine($"Price per Person: {this.PricePerPerson}");

            return info.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            var info = new StringBuilder();
            info.AppendLine(BaseTableInfo());
            info.AppendLine($"Number of people: {this.NumberOfPeople}");
            info.AppendLine($"Food {GetOrders(this.FoodOrders)}");
            info.AppendLine($"Drink {GetOrders(this.DrinkOrders)}");

            return info.ToString().TrimEnd();
        }

        private string BaseTableInfo()
        {
            return $"Table: {this.TableNumber}{Environment.NewLine}Type: {this.GetType().Name}";
        }

        private string GetOrders(IReadOnlyCollection<object> orders)
        {
            var ordersInfo = new StringBuilder();

            if (orders.Count == 0)
            {
                ordersInfo.AppendLine($"orders: None");
            }
            else
            {
                ordersInfo.AppendLine($"orders: {orders.Count}");

                foreach (var order in orders)
                {
                    ordersInfo.AppendLine(order.ToString());
                }
            }

            return ordersInfo.ToString().TrimEnd();
        }
    }
}