namespace CarsSalesman
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var catalogue = new Catalogue();

            var enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                catalogue.AddEngine(parameters);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                catalogue.AddCar(parameters);
            }

            foreach (var car in catalogue.Cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}