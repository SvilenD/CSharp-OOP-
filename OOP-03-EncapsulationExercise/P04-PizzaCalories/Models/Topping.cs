namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;

    public class Topping 
    {
        private const double BaseCalloriesPerGram = 2;
        private const string InvalidWeightMsg = "{0} weight should be in the range[1..50].";
        private const string InvalidToppingMsg = "Cannot place {0} on top of your pizza.";

        private string type;
        private double weight;
        private Dictionary<string, double> validTypes;

        public Topping(string type, double weight)
        {
            this.validTypes = new Dictionary<string, double>();
            this.ValidToppingTypes();
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                if (validTypes.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException(string.Format(InvalidWeightMsg), value);
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(InvalidWeightMsg), this.Type);
                }

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                return BaseCalloriesPerGram
                    * this.weight
                    * this.validTypes[this.Type.ToLower()];
            }
        }

        private void ValidToppingTypes()
        {
            this.validTypes.Add("meat", 1.2);
            this.validTypes.Add("veggies", 0.8);
            this.validTypes.Add("cheese", 1.1);
            this.validTypes.Add("sauce", 0.9);
        }
    }
}