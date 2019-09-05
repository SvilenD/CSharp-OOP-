using System;

namespace E05_KingsGambit.Models.Contracts
{
    public interface IMortal
    {
        int Lives { get; }

        void GetHit();

        event EventHandler SoldierDead;
    }
}