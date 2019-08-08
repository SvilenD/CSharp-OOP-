namespace PlayersAndMonsters.Core
{
    using System;
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IManagerController managerController;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split();
                if (input[0] == "Exit")
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
                    case "AddPlayer":
                        return managerController.AddPlayer(input[1], input[2]);
                    case "AddCard":
                        return managerController.AddCard(input[1], input[2]);
                    case "AddPlayerCard":
                        return managerController.AddPlayerCard(input[1], input[2]);
                    case "Fight":
                        return managerController.Fight(input[1], input[2]);
                    case "Report":
                        return managerController.Report();
                    default:
                        return "Invalid command!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}