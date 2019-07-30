namespace ShoppingSpree
{
    using System;
    using ShoppingSpree.Models;

    public class Engine
    {
        private People people;
        private ProductsList products;

        public Engine()
        {
            people = new People(Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries));
            products = new ProductsList(Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries));
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine()?.Split();
                if (command[0]?.ToUpper() == "END")
                {
                    break;
                }

                var name = command[0];
                var item = command[1];
                var person = people.FindPerson(name);
                var product = products.FindProduct(item);

                try
                {
                    Console.WriteLine(person.AddProduct(product));
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public void Print()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }
    }
}