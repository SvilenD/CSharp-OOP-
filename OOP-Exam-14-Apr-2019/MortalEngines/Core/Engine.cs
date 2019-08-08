namespace MortalEngines.Core
{
    using System;
    using MortalEngines.IO;
    using MortalEngines.Core.Contracts;
    using MortalEngines.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly MachinesManager manager;
        private readonly Reader reader;
        private readonly Writer writer;

        public Engine()
        {
            this.manager = new MachinesManager();
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            var commands = reader.ReadCommands();

            foreach (var command in commands)
            {
                writer.Write(Execute(command));
            }
        }

        private string Execute(ICommand command)
        {
            try
            {
                switch (command.Name)
                {
                    case "HirePilot":
                        var name = command.Params[0];

                        return manager.HirePilot(name);
                    case "PilotReport":
                        name = command.Params[0];

                        return manager.PilotReport(name);
                    case "ManufactureTank":
                        name = command.Params[0];
                        var attack = double.Parse(command.Params[1]);
                        var defense = double.Parse(command.Params[2]);

                        return manager.ManufactureTank(name, attack, defense);
                    case "ManufactureFighter":
                        name = command.Params[0];
                        attack = double.Parse(command.Params[1]);
                        defense = double.Parse(command.Params[2]);

                        return manager.ManufactureFighter(name, attack, defense);
                    case "MachineReport":
                        name = command.Params[0];

                        return manager.MachineReport(name);
                    case "AggressiveMode":
                        name = command.Params[0];

                        return manager.ToggleFighterAggressiveMode(name);
                    case "DefenseMode":
                        name = command.Params[0];

                        return manager.ToggleTankDefenseMode(name);
                    case "Engage":
                        var pilotName = command.Params[0];
                        var machineName = command.Params[1];

                        return manager.EngageMachine(pilotName, machineName);
                    case "Attack":
                        var attacker = command.Params[0];
                        var defender = command.Params[1];

                        return manager.AttackMachines(attacker, defender);
                    default:
                        return "Invalid command!";
                }
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}