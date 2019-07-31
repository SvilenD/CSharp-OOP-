namespace MortalEngines.Entities.Machines
{
    using System;
    using MortalEngines.Entities.Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private static int DEFAULT_HealthPoints = 200;
        private const int ATTACK_POINTS_TO_INCREASE = 50;
        private const int DEFENSE_POINTS_TO_DECREASE = 25;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, DEFAULT_HealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;

                this.AttackPoints += ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_DECREASE;
            }
            else
            {
                this.AggressiveMode = false;

                this.AttackPoints -= ATTACK_POINTS_TO_INCREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_DECREASE;
            }
        }

        public override string ToString()
        {
            var aggressiveMode = this.AggressiveMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveMode}";
        }
    }
}