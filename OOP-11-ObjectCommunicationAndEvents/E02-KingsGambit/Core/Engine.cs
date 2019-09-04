namespace E02_KingsGambit.Core
{
    using E02_KingsGambit.Models;
    using E02_KingsGambit.Models.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly HashSet<IFigure> figures;
        private readonly King king;

        public Engine(King king)
        {
            this.figures = new HashSet<IFigure>();
            this.king = king;
        }

        public void Run()
        {
            this.king.KingAttacked += king.OnAttack;

            AddFigures();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if (command == "Attack King")
                {
                    this.king.GetAttacked(this.king);
                }
                else
                {
                    var figureName = command.Split()[1];
                    var figureToRemove = this.figures.FirstOrDefault(f => f.Name == figureName);

                    this.king.KingAttacked -= figureToRemove.OnAttack;
                    figures.Remove(figureToRemove);
                }
            }
        }

        private void AddFigures()
        {
            var guardsNames = Console.ReadLine().Split();
            for (int i = 0; i < guardsNames.Length; i++)
            {
                var guard = new RoyalGuard(guardsNames[i]);

                this.figures.Add(guard);
                this.king.KingAttacked += guard.OnAttack;
            }

            var footmenNames = Console.ReadLine().Split();
            for (int i = 0; i < footmenNames.Length; i++)
            {
                var footman = new Footman(footmenNames[i]);

                this.figures.Add(footman);
                this.king.KingAttacked += footman.OnAttack;
            }
        }
    }
}