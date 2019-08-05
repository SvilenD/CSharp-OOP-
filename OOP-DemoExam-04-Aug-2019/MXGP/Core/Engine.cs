namespace MXGP.Core
{
    using System;
    using MXGP.IO;
    using MXGP.Core.Contracts;

    public class Engine : IEngine
    {
        private ChampionshipController controller;
        private ConsoleReader reader;
        private ConsoleWriter writer;

        public Engine()
        {
            this.controller = new ChampionshipController();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                var result = ExecuteCommand(input);

                writer.WriteLine(result);
            }
        }

        private string ExecuteCommand(string[] input)
        {
            try
            {
                switch (input[0])
                {
                    case "CreateRider":
                        return controller.CreateRider(input[1]);
                    case "CreateMotorcycle":
                        return controller.CreateMotorcycle(input[1], input[2], int.Parse(input[3]));
                    case "CreateRace":
                        return controller.CreateRace(input[1], int.Parse(input[2]));
                    case "AddMotorcycleToRider":
                        return controller.AddMotorcycleToRider(input[1], input[2]);
                    case "AddRiderToRace":
                        return controller.AddRiderToRace(input[1], input[2]);
                    case "StartRace":
                        return controller.StartRace(input[1]);
                }
            }
            catch (Exception ex)
            {
                writer.Write(ex.Message);
            }
            return null;
        }
    }
}