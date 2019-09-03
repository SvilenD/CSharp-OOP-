namespace E01_EventImplementation
{
    using System;

    public class Handler
    {
        private string NameChangeMsg = "Dispatcher's name changed to {0}.";

        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine(String.Format(NameChangeMsg, args.Name));
        }
    }
}