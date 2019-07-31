namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using MortalEngines.IO;
    using System;

    public class Engine : IEngine
    {
        private readonly IMachinesManager machinesManager;
        private readonly Reader reader;
        private readonly Writer writer;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
            this.reader = new Reader();
            this.writer = new Writer();
        }

        public void Run()
        {
            var commands = reader.ReadCommands();

            try
            {
                foreach (var command in commands)
                {
                    switch (command.Name)
                    {
                        case "HirePilot":
                            var name = command.Params[0];
                            writer.Write(machinesManager.HirePilot(name));
                            break;
                        case "PilotReport":
                            name = command.Params[0];
                            writer.Write(machinesManager.PilotReport(name));
                            break;
                        case "ManufactureTank":
                            name = command.Params[0];
                            var attack = double.Parse(command.Params[1]);
                            var defense = double.Parse(command.Params[2]);
                            writer.Write(machinesManager.ManufactureTank(name, attack, defense));
                            break;
                        case "ManufactureFighter":
                            name = command.Params[0];
                            attack = double.Parse(command.Params[1]);
                            defense = double.Parse(command.Params[2]);
                            writer.Write(machinesManager.ManufactureFighter(name, attack, defense));
                            break;
                        case "MachineReport":
                            name = command.Params[0];
                            writer.Write(machinesManager.MachineReport(name));
                            break;
                        case "AggressiveMode":
                            name = command.Params[0];
                            writer.Write(machinesManager.ToggleFighterAggressiveMode(name));
                            break;
                        case "DefenseMode":
                            name = command.Params[0];
                            writer.Write(machinesManager.ToggleTankDefenseMode(name));
                            break;
                        case "Engage":
                            var pilotName = command.Params[0];
                            var machineName = command.Params[1];
                            writer.Write(machinesManager.EngageMachine(pilotName, machineName));
                            break;
                        case "Attack":
                            var attacker = command.Params[0];
                            var defender = command.Params[1];
                            writer.Write(machinesManager.AttackMachines(attacker, defender));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                writer.Write("Error: " + ex.Message);
            }
        }
    }
}