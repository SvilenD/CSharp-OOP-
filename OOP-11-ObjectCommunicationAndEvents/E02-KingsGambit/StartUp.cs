namespace E02_KingsGambit
{
    using E02_KingsGambit.Core;
    using E02_KingsGambit.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var kingsName = Console.ReadLine();
            var king = new King(kingsName);
            var engine = new Engine(king);
            engine.Run();
        }
    }
}