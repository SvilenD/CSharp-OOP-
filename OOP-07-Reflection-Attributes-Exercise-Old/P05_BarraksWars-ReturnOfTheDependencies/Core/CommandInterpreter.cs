namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandNameSuffix = "command";
        //private readonly IRepository repository;
        //private readonly IUnitFactory unitFactory;

        //public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        //{
        //    this.repository = repository;
        //    this.unitFactory = unitFactory;
        //}

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var instanceName = commandName + CommandNameSuffix;

            var type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == instanceName);

            return (IExecutable)Activator.CreateInstance(type, new object[] { data/*, this.repository, this.unitFactory */});
        }
    }
}