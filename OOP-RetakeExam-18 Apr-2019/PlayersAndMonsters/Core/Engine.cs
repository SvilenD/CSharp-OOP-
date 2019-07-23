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
                try
                {
                    switch (input[0])
                    {
                        case "AddPlayer":
                            writer.WriteLine(managerController.AddPlayer(input[1], input[2]));
                            break;
                        case "AddCard":
                            writer.WriteLine(managerController.AddCard(input[1], input[2]));
                            break;
                        case "AddPlayerCard":
                            writer.WriteLine(managerController.AddPlayerCard(input[1], input[2]));
                            break;
                        case "Fight":
                            writer.WriteLine(managerController.Fight(input[1], input[2]));
                            break;
                        case "Report":
                            writer.WriteLine(managerController.Report());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}