namespace VehiclesExtension
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var car = new Car(ParseData());
            var truck = new Truck(ParseData());
            var bus = new Bus(ParseData());

            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var commandArgs = Console.ReadLine().Split();

                var command = commandArgs[0];
                var type = commandArgs[1];

                try
                {
                    if (command == "Drive")
                    {
                        var distance = double.Parse(commandArgs[2]);

                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else
                        {
                            Console.WriteLine(bus.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double fuel = double.Parse(commandArgs[2]);

                        if (type == "Car")
                        {
                            car.Refuel(fuel);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(fuel);
                        }
                        else
                        {
                            bus.Refuel(fuel);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        var distance = double.Parse(commandArgs[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static double[] ParseData()
        {
            return Console.ReadLine()
                .Split()
                .Skip(1)
                .Select(double.Parse)
                .ToArray();
        }
    }
}