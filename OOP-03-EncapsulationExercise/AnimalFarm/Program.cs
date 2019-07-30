namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;

    class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            try
            {
                var chicken = new Chicken(name, age);
                Console.WriteLine(chicken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}