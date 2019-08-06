namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public abstract class Animal
    {
        protected const string DEFAULT_WrongFoodMsg = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        protected abstract List<string> FoodsEating { get; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        protected abstract double IncreaseWeight { get; }

        public void Eat(Food food)
        {
            if (FoodsEating.Contains(food.GetType().Name) == false)
            {
                throw new ArgumentException(String.Format(DEFAULT_WrongFoodMsg, this.GetType().Name, food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * IncreaseWeight;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}