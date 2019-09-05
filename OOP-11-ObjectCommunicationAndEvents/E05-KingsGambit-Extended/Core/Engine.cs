namespace E05_KingsGambit.Core
{
    using E05_KingsGambit.Models;
    using System;

    public class Engine
    {
        private readonly King king;

        public Engine(King king)
        {
            this.king = king;
        }

        public void Run()
        {
            this.king.KingAttacked += king.OnAttack;

            AddSoldiers();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if (command == "Attack King")
                {
                    this.king.GetAttacked();
                }
                else
                {
                    var soldierName = command.Split()[1];
                    var soldier = this.king.GetSoldier(soldierName);
                    soldier.GetHit();
                }
            }
        }

        private void AddSoldiers()
        {
            var guardsNames = Console.ReadLine().Split();
            for (int i = 0; i < guardsNames.Length; i++)
            {
                var guard = new RoyalGuard(guardsNames[i]);

                this.king.AddSoldier(guard);
            }

            var footmenNames = Console.ReadLine().Split();
            for (int i = 0; i < footmenNames.Length; i++)
            {
                var footman = new Footman(footmenNames[i]);

                this.king.AddSoldier(footman);
            }
        }
    }
}