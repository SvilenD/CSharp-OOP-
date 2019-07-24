namespace Animals
{
    using System;
    using Animals.Models;

    public static class Engine
    {
        public static void Run()
        {
            while (true)
            {
                var animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }

                var data = Console.ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);
                var gender = data[2] ?? string.Empty;

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;

                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;

                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;

                        case "Kitten":
                            var kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            break;

                        case "Tomcat":
                            var tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}