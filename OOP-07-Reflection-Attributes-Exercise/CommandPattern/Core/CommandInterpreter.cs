namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandNamePostFix = "Command";

        public string Read(string args)
        {
            var commandArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var className = commandArgs[0] + CommandNamePostFix;

            var assembly = Assembly.GetCallingAssembly();

            var type = assembly.GetTypes().FirstOrDefault(x=>x.Name == className);

            var instance = (ICommand)Activator.CreateInstance(type);

            return instance.Execute(commandArgs.Skip(1).ToArray());
        }
    }
}
