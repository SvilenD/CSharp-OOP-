namespace Vehicles
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();
            int linesCount = int.Parse(Console.ReadLine());

            var carFuelQuantity = double.Parse(carArgs[1]);
            var carFuelConsumption = double.Parse(carArgs[2]);
            var car = new Car(carFuelQuantity, carFuelConsumption);

            var truckFuelQuantity = double.Parse(truckArgs[1]);
            var truckFuelConsumption = double.Parse(truckArgs[2]);
            var truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            for (int i = 0; i < linesCount; i++)
            {
                var commandArgs = Console.ReadLine().Split();

                var command = commandArgs[0];
                var type = commandArgs[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(commandArgs[2]);

                    if (type == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(commandArgs[2]);

                    if (type == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}