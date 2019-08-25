namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using P03_BarraksWars.Core;

    class Engine : IRunnable
    {
        private CommandInterpreter interpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.interpreter = new CommandInterpreter(repository, unitFactory);
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