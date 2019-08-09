namespace SoftUniRestaurant.Core
{
    using System;
    using SoftUniRestaurant.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly CommandInterpreter interpreter;

        public Engine()
        {
            this.interpreter = new CommandInterpreter();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }

                var result = this.interpreter.ExecuteCommand(input);
                Console.WriteLine(result);
            }

            Console.WriteLine(this.interpreter.GetSummary());
        }
    }
}