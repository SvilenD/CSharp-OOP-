namespace MortalEngines.IO
{
    using MortalEngines.IO.Contracts;

    public class Command : ICommand
    {
        public Command(string name, params string[] parameters)
        {
            this.Name = name;
            this.Params = parameters;
        }

        public string Name { get; private set; }

        public string[] Params { get; private set; }
    }
}