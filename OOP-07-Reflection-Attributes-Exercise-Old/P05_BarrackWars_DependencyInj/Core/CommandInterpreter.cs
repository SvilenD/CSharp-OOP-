namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandNameSuffix = "command";

        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var instanceName = commandName + CommandNameSuffix;

            var type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == instanceName);

            var instance = (IExecutable)Activator.CreateInstance(type, new object[] { data });

            var fields = instance.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)));

            foreach (var field in fields)
            {
                var value = serviceProvider.GetService(field.FieldType);
                field.SetValue(instance, value);
            }

            return instance;
        }
    }
}