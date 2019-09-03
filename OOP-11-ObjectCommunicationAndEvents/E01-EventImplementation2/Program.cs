namespace E01_EventImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (true)
            {
                var name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                dispatcher.Name = name;
            }
        }
    }
}