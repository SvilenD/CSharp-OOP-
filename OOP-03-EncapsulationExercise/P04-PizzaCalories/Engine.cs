namespace PizzaCalories
{
    using System;
    using PizzaCalories.Models;

    public class Engine
    {
        public void Run()
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split();
                var pizzaName = pizzaArgs[1];

                var doughArgs = Console.ReadLine().Split();
                var flourType = doughArgs[1];
                var bakingTech = doughArgs[2];
                var flourWeight = double.Parse(doughArgs[3]);
                var dough = new Dough(flourType, bakingTech, flourWeight);

                var pizza = new Pizza(pizzaName, dough);

                var input = Console.ReadLine().Split();

                while (input[0] != "END")
                {
                    var type = input[1];
                    var weight = double.Parse(input[2]);
                    var topping = new Topping(type, weight);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}