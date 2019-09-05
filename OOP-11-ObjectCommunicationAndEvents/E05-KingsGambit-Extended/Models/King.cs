namespace E05_KingsGambit.Models
{
    using E05_KingsGambit.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class King : IFigure
    {
        private readonly HashSet<Soldier> soldiers;

        public King(string name) 
        {
            this.Name = name;
            this.soldiers = new HashSet<Soldier>();
        }

        public string Name { get; }

        public string Response => $"King {this.Name} is under attack!";

        public event EventHandler KingAttacked;

        public void AddSoldier(Soldier soldier)
        {
            this.soldiers.Add(soldier);
            this.KingAttacked += soldier.OnAttack;
            soldier.SoldierDead += this.DeadSoldier;
        }

        public Soldier GetSoldier(string soldierName)
        {
            return this.soldiers.FirstOrDefault(s => s.Name == soldierName);
        }

        public void GetAttacked()
        {
            this.KingAttacked?.Invoke(this, EventArgs.Empty);
        }

        public void OnAttack(object sender, EventArgs args)
        {
            Console.WriteLine(this.Response);
        }

        private void DeadSoldier(object sender, EventArgs args)
        {
            var soldier = (Soldier)sender;
            this.KingAttacked -= soldier.OnAttack;
            this.soldiers.Remove(soldier);
        }
    }
}