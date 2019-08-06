namespace AnimalCentre.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly CommandInterpreter command;

        public Engine()
        {
            this.command = new CommandInterpreter();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                if (input[0] == "End")
                {
                    break;
                }

                try
                {
                    Console.WriteLine(command.Execute(input));
                }
                catch (InvalidOperationException invalidOp)
                {
                    Console.WriteLine("InvalidOperationException: " + invalidOp.Message);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine("ArgumentException: " + argEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(command.GetHistory());
        }
    }
}