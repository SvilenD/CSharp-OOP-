namespace WildFarm
{
    using System;
    using System.Collections.Generic;

    using WildFarm.Factories;
    using WildFarm.Animals;

    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                var animal = AnimalFactory.Create(input);
                Console.WriteLine(animal.ProduceSound());

                var foodArgs = Console.ReadLine().Split();
                var food = FoodFactory.Create(foodArgs);

                try
                {
                animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}