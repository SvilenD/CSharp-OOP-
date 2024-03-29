﻿namespace MortalEngines.Entities.Machines
{
    using System;
    using MortalEngines.Entities.Contracts;

    public class Tank : BaseMachine, ITank
    {
        private static int DEFAULT_HealthPoints = 100;
        private const int ATTACK_POINTS_TO_DECREASE = 40;
        private const int DEFENSE_POINTS_TO_INCREASE = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, DEFAULT_HealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= ATTACK_POINTS_TO_DECREASE;
                this.DefensePoints += DEFENSE_POINTS_TO_INCREASE;
            }
            else
            {
                this.DefenseMode = false;

                this.AttackPoints += ATTACK_POINTS_TO_DECREASE;
                this.DefensePoints -= DEFENSE_POINTS_TO_INCREASE;
            }
        }

        public override string ToString()
        {
            var deffensive = this.DefenseMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Defense: {deffensive}";
        }
    }
}