namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.IO;

    public class Engine : IEngine
    {
        private readonly CommandInterpreter command;
        private readonly ConsoleReader reader;
        private readonly ConsoleWriter writer;

        public Engine()
        {
            this.command = new CommandInterpreter();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine()
                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                var result = command.Execute(input);
                writer.WriteLine(result);
            }
        }
    }
}