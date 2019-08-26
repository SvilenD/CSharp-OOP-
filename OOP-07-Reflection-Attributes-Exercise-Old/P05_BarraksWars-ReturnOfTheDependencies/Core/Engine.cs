namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using P03_BarraksWars.Core;

    public class Engine : IRunnable
    {
        private readonly CommandInterpreter interpreter;

        public Engine(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var data = input.Split();
                    var commandName = data[0];

                    var instance = interpreter.InterpretCommand(data, commandName);

                    var result = instance.Execute();

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}