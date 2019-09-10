using System;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : IPoint
    {
        public Food(int x, int y,int points, char symbol)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
            this.Points = points;
            this.Symbol = symbol;
        }

        public int CoordinateX { get; }

        public int CoordinateY { get; }

        public virtual char Symbol { get; }

        public int Points { get; }
    }
}
