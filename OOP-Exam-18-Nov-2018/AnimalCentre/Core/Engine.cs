namespace AnimalCentre.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private AnimalCentre center;
        public Engine()
        {
            this.center = new AnimalCentre();
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                if (command[0] == "End")
                {
                    break;
                }

                try
                {
                    Console.WriteLine(ExecuteCommand(command));
                }
                catch (InvalidOperationException invalidOp)
                {
                    Console.WriteLine("InvalidOperationException: " + invalidOp.Message);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine("ArgumentException: " + argEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(center.AdobtedHistory());
        }

        private string ExecuteCommand(string[] input)
        {
            switch (input[0])
            {
                case "RegisterAnimal":
                    return center.RegisterAnimal(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]));
                case "Chip":
                    return center.Chip(input[1], int.Parse(input[2]));
                case "Adopt":
                    return center.Adopt(input[1], input[2]);
                case "DentalCare":
                    return center.DentalCare(input[1], int.Parse(input[2]));
                case "Fitness":
                    return center.Fitness(input[1], int.Parse(input[2]));
                case "History":
                    return center.History(input[1]);
                case "NailTrim":
                    return center.NailTrim(input[1], int.Parse(input[2]));
                case "Play":
                    return center.Play(input[1], int.Parse(input[2]));
                case "Vaccinate":
                    return center.Vaccinate(input[1], int.Parse(input[2]));
            }

            return "Invalid command";
        }
    }
}