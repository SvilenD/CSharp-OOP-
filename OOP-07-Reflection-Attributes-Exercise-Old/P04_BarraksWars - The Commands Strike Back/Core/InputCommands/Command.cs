namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.UnitFactory = unitFactory;
            this.Repository = repository;
        }

        protected string[] Data { get; private set; }

        protected IUnitFactory UnitFactory { get; private set; }

        protected IRepository Repository { get; private set; }

        public abstract string Execute();
    }
}