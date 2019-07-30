namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private const string DefaultNameErrorMsg = "Pizza name should be between 1 and 15 symbols.";
        private const string DefaultToppingsErrorMsg = "Number of toppings should be in range [0..10].";

        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException(DefaultNameErrorMsg);
                }

                this.name = value;
            }
        }

        public int ToppingsCount
        {
            get
            {
                return this.toppings.Count;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.ToppingsCount == 10)
            {
                throw new ArgumentException(DefaultToppingsErrorMsg);
            }

            this.toppings.Add(topping);
        }

        public double TotalCalories
        {
            get
            {
                return this.dough.Calories + this.toppings.Select(x => x.Calories).Sum();
            }
        }
    }
}