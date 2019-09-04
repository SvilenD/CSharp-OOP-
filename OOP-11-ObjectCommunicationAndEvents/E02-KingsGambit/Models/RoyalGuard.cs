using System;

namespace E02_KingsGambit.Models
{
    public class RoyalGuard : Figure
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public override string Response => $"Royal Guard {this.Name} is defending!";
    }
}