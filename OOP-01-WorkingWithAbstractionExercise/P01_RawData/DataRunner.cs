namespace RawData
{
    using System;

    internal class DataRunner
    {
        public void Run()
        {
            var cars = new CarsCatalogue();

            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var parameters = Console.ReadLine()
                    ?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var assembly = new Assembly(parameters);
                var car = assembly.CreateCar();

                cars.Add(car);
            }

            var filter = Console.ReadLine();

            PrintResult(filter, cars);
        }

        private void PrintResult(string filter, CarsCatalogue cars)
        {
            foreach (var car in cars.Filter(filter))
            {
                Console.WriteLine(car);
            }
        }
    }
}
