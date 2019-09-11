namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using SimpleSnake.GameObjects;

    public static class DrawManager
    {
        private const int ScoreX = 2;
        private const int ScoreY = 0;
        private const string ScoreMsg = " Score: {0:D7}. Level: {1:D3} ";
        private const int InfoX = 70;
        private const int InfoY = 0;

        public static void DrawSnake(IEnumerable<IPoint> points)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var point in points)
            {
                Draw(point);
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void DrawFrame(IEnumerable<IPoint> points)
        {
            foreach (var point in points)
            {
                Draw(point);
            }
        }

        public static void ClearPoint(IPoint point)
        {
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(' ');
        }

        public static void DrawFood(IPoint point)
        {
            Draw(point);
        }

        public static void WriteScore(int score, sbyte level)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(ScoreX, ScoreY);
            Console.WriteLine(string.Format(ScoreMsg, score, level));
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void WriteMsg(string msg)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(InfoX, InfoY);
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void Draw(IPoint point)
        {
            Console.SetCursorPosition(point.CoordinateX, point.CoordinateY);
            Console.Write(point.Symbol);
        }
    }
}