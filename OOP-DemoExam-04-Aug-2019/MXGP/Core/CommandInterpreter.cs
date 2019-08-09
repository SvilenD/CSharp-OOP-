namespace MXGP.Core
{
    using System;
    using MXGP.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ChampionshipController controller;

        public CommandInterpreter()
        {
            this.controller = new ChampionshipController();
        }

        public string Execute(string[] input)
        {
            try
            {
                switch (input[0])
                {
                    case "CreateRider":
                        return controller.CreateRider(input[1]);
                    case "CreateMotorcycle":
                        return controller.CreateMotorcycle(input[1], input[2], int.Parse(input[3]));
                    case "AddMotorcycleToRider":
                        return controller.AddMotorcycleToRider(input[1], input[2]);
                    case "AddRiderToRace":
                        return controller.AddRiderToRace(input[1], input[2]);
                    case "CreateRace":
                        return controller.CreateRace(input[1], int.Parse(input[2]));
                    case "StartRace":
                        return controller.StartRace(input[1]);
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}