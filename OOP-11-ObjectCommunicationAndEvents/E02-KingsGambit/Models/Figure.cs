namespace E02_KingsGambit.Models
{
    using System;
    using E02_KingsGambit.Models.Contracts;

    public abstract class Figure : IFigure
    {
        protected Figure(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract string Response { get; }

        public void OnAttack(object sender, EventArgs args)
        {
            Console.WriteLine(this.Response);
        }
    }
}