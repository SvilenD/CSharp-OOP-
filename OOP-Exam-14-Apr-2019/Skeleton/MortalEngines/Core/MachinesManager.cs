namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly Dictionary<string, IPilot> pilots;
        private readonly Dictionary<string, IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.ContainsKey(name))
            {
                return String.Format(OutputMessages.PilotExists, name);
            }

            var pilot = new Pilot(name);
            this.pilots.Add(name, pilot);
            return String.Format(OutputMessages.PilotHired, name);
        }

        public string PilotReport(string pilotReporting)
        {
            return this.pilots.FirstOrDefault(p => p.Key == pilotReporting).Value.Report();
        }

        public string MachineReport(string machineName)
        {
            return this.machines.FirstOrDefault(p => p.Key == machineName).Value.ToString();
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            var tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(name, tank);

            return String.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = machines.FirstOrDefault(t => t.Key == tankName).Value;
            if (tank == null)
            {
                return String.Format(OutputMessages.MachineNotFound, tankName);
            }
            var tankFound = tank as Tank;
            tankFound.ToggleDefenseMode();

            return String.Format(OutputMessages.TankOperationSuccessful, tankName);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return String.Format(OutputMessages.MachineExists, name);
            }

            var fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(name, fighter);
            var aggressiveMode = fighter.AggressiveMode ? "ON" : "OFF";
            return String.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, aggressiveMode);
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = machines.FirstOrDefault(t => t.Key == fighterName).Value;
            if (fighter == null)
            {
                return String.Format(OutputMessages.MachineNotFound, fighterName);
            }

            var fighterFound = fighter as Fighter;
            fighterFound.ToggleAggressiveMode();

            return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.FirstOrDefault(p => p.Key == selectedPilotName).Value;
            if (pilot == null)
            {
                return String.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            var machine = this.machines.FirstOrDefault(m => m.Key == selectedMachineName).Value;
            if (machine == null)
            {
                return String.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (machine.Pilot != null)
            {
                return String.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);
            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(m => m.Key == attackingMachineName).Value;
            if (attacker == null)
            {
                return String.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            var defender = this.machines.FirstOrDefault(m => m.Key == defendingMachineName).Value;
            if (defender == null)
            {
                return String.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attacker.HealthPoints == 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            if (defender.HealthPoints == 0)
            {
                return String.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(defender);
            return String.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints);
        }

    }
}