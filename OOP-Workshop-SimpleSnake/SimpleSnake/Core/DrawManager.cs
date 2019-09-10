namespace SimpleSnake.Core
{
    using SimpleSnake.GameObjects;
    using System;
    using System.Collections.Generic;

    public class DrawManager
    {
        private const int ScoreX = 2;
        private const int ScoreY = 1;
        private const string InfoMsg = " Score: {0:D7}. Level: {1:D3} ";

        public void DrawSet(IEnumerable<IPoint> points)
        {
            foreach (var point in points)
            {
                Draw(point);
            }
        }

        public void ClearPoint(IPoint point)
        {
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(' ');
        }

        public void DrawFood(IPoint point)
        {
            Draw(point);
        }

        public void WriteScore(int score, sbyte level)
        {
            Console.SetCursorPosition(ScoreX, ScoreY);
            Console.WriteLine(string.Format(InfoMsg, score, level));
        }

        private void Draw(IPoint point)
        {
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(point.Symbol);
        }
    }
}