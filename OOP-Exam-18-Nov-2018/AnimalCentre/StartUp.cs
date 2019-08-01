using AnimalCentre.Models.Animals;
using AnimalCentre.Core;
using AnimalCentre.Models.Procedures;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //TODO Run your application from here

            var engine = new Engine();
            engine.Run();

            //var animalsCenter = new Core.AnimalCentre();

            //Console.WriteLine(animalsCenter.RegisterAnimal("Cat", "pesho", 3, 3, 4)); 

            ////var cat = new Cat("gosho", 10, 10, 10);

            ////var procedure = new Chip();
            ////procedure.DoService(cat, 1);
            ////try
            ////{
            ////    procedure.DoService(cat, 2);
            ////}
            ////catch (Exception)
            ////{
            ////}
            ////Console.WriteLine(cat);
            ////Console.WriteLine(procedure.History());
        }
    }
}