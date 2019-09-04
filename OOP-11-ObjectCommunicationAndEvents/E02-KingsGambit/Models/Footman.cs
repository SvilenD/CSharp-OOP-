using System;

namespace E02_KingsGambit.Models
{
    public class Footman : Figure
    {
        public Footman(string name) 
            : base(name)
        {
        }

        public override string Response => $"Footman {this.Name} is panicking!";
    }
}