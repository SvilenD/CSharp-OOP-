namespace E01_EventImplementation
{
    using System;

    public class Handler
    {
        private const string NameChangeMsg = "Dispatcher's name changed to {0}.";
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine(string.Format(NameChangeMsg, args.Name));
        }
    }
}