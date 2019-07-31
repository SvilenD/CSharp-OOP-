using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        private IList<ICommand> commands;

        public Reader()
        {
            this.commands = new List<ICommand>();
        }

        public IList<ICommand> ReadCommands()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];
                if (command == "Quit")
                {
                    break;
                }
                var parameters = input.Skip(1).ToArray();

                commands.Add(new Command(command, parameters));
            }

            return commands;
        }
    }
}