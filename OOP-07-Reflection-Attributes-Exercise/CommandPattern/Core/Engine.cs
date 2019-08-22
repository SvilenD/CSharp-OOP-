namespace CommandPattern.Core
{
    using System;
    using CommandPattern.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var command = Console.ReadLine();

            Console.WriteLine(commandInterpreter.Read(command));
        }
    }
}
