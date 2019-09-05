namespace E05_KingsGambit
{
    using E05_KingsGambit.Core;
    using E05_KingsGambit.Models;
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