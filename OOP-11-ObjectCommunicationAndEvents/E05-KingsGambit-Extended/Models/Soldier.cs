namespace E05_KingsGambit.Models
{
    using System;
    using E05_KingsGambit.Models.Contracts;

    public abstract class Soldier : IFigure, IMortal
    {
        protected Soldier(string name,  int lives)
        {
            this.Name = name;
            this.Lives = lives;
        }

        public string Name { get; }

        public abstract string Response { get; }

        public int Lives { get; private set; }

        public event EventHandler SoldierDead;

        public void OnAttack(object sender, EventArgs args)
        {
            Console.WriteLine(this.Response);
        }

        public void GetHit()
        {
            this.Lives--;
            if (this.Lives == 0)
            {
                this.SoldierDead.Invoke(this, EventArgs.Empty);
            }
        }
    }
}