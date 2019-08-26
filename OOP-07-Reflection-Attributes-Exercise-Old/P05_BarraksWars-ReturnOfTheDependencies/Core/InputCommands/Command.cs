namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract string Execute();
    }
}