namespace ViceCity.Core
{
    using System;
    using ViceCity.IO;
    using ViceCity.IO.Contracts;
    using ViceCity.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly Controller controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                var result = string.Empty;

                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        result = this.controller.AddPlayer(input[1]);
                    }
                    else if (input[0] == "AddGun")
                    {
                        result = this.controller.AddGun(input[1], input[2]);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        result = this.controller.AddGunToPlayer(input[1]);
                    }
                    else if (input[0] == "Fight")
                    {
                        result = this.controller.Fight();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}