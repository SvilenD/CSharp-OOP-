namespace MortalEngines.Entities.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private readonly List<string> targets;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullMachineName);
                }

                this.name = value;
            }
        }
        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get; set; }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(ExceptionMessages.NullPilot);
                }

                this.pilot = value;
            }
        }

        public IList<string> Targets => this.targets.AsReadOnly();

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullTarget);
            }
            if (targets.Contains(target.Name) == false)
            {
                this.targets.Add(target.Name);
            }

            target.HealthPoints -= (this.AttackPoints - target.DefensePoints);
            if (target.HealthPoints <= 0)
            {
                target.HealthPoints = 0;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints:F2}");
            result.AppendLine($" *Attack: {this.AttackPoints:F2}");
            result.AppendLine($" *Defense: {this.DefensePoints:F2}");
            result.Append(" *Targets: ");
            if (this.targets.Count == 0)
            {
                result.Append("None");
            }
            else
            {
                result.Append(string.Join(",", targets));
            }

            return result.ToString().TrimEnd();
        }
    }
}