namespace SoftUniRestaurant.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Tables.Contracts;
    using SoftUniRestaurant.Common;
    using SoftUniRestaurant.Core.Contracts;
    using SoftUniRestaurant.Core.Factories;

    public class RestaurantController : IRestaurantController
    {
        private readonly FoodFactory foodFactory;
        private readonly DrinkFactory drinkFactory;
        private readonly TableFactory tableFactory;
        private readonly List<IFood> menu;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome;

        public RestaurantController()
        {
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0m;
        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = foodFactory.CreateFood(type, name, price);

            this.menu.Add(food);
            return String.Format(OutputMessages.ADD_Food, food.Name, food.GetType().Name, food.Price);
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);

            this.drinks.Add(drink);
            return String.Format(OutputMessages.ADD_Drink, drink.Name, drink.Brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var table = this.tableFactory.CreateTable(type, tableNumber, capacity);
           
            tables.Add(table);

            return string.Format(OutputMessages.ADD_Table, tableNumber, capacity);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return String.Format(OutputMessages.NO_Table, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return String.Format(OutputMessages.RESERVE_Table, table.TableNumber, numberOfPeople);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = FindTable(tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.TABLE_NotExists, tableNumber);
            }

            var food = menu.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return String.Format(OutputMessages.FOOD_NotExists, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.ORDERED_Food, tableNumber, foodName);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = FindTable(tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.TABLE_NotExists, tableNumber);
            }

            var drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return String.Format(OutputMessages.DRINK_NotExists, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return String.Format(OutputMessages.ORDERED_Drink, tableNumber, drinkName, drinkBrand);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.FindTable(tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.TABLE_NotExists, tableNumber);
            }

            var bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();

            return String.Format(OutputMessages.LEAVE_Table, tableNumber, Environment.NewLine, bill).TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var freeTablesInfo = new StringBuilder();
            foreach (var table in this.tables.Where(t => t.IsReserved == false))
            {
                freeTablesInfo.AppendLine(table.GetFreeTableInfo());
            }

            return freeTablesInfo.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTablesInfo = new StringBuilder();
            foreach (var table in this.tables.Where(t => t.IsReserved == true))
            {
                occupiedTablesInfo.AppendLine(table.GetOccupiedTableInfo());
            }

            return occupiedTablesInfo.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return String.Format(OutputMessages.TOTAL_Income, this.totalIncome);
        }

        private ITable FindTable(int tableNumber)
        {
            return tables.FirstOrDefault(t => t.TableNumber == tableNumber);
        }
    }
}