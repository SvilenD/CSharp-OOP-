namespace E01_EventImplementation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var disp = new Dispatcher();
            var handler = new Handler();

            disp.NameChange += handler.OnDispatcherNameChange;

            var name = Console.ReadLine();

            while (name != "End")
            {
                disp.Name = name;

                name = Console.ReadLine();
            }
        }
    }
}