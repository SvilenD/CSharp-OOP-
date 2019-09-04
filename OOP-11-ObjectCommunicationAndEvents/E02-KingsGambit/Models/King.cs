namespace E02_KingsGambit.Models
{
    using System;

    public class King : Figure
    {
        public King(string name) 
            : base(name)
        {
        }

        public override string Response => $"King {this.Name} is under attack!";

        public event EventHandler KingAttacked;

        public void GetAttacked()
        {
            this.KingAttacked?.Invoke(this, EventArgs.Empty);
        }
    }
}