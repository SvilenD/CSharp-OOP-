using System;

namespace E02_KingsGambit.Models.Contracts
{
    public interface IFigure
    {
        string Name { get; }

        string Response { get; }

        void OnAttack(object sender, EventArgs args);
    }
}