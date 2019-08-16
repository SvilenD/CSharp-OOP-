namespace LoggerProject.Core
{
    using System;
    using LoggerProject.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                var appenderArgs = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(appenderArgs);
            }

            while (true)
            {
                var reportArgs = Console.ReadLine().Split('|');

                if (reportArgs[0].ToUpper() == "END")
                {
                    break;
                }

                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}