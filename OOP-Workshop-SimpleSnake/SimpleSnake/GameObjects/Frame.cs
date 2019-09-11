namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;

    public class Frame
    {
        private readonly List<FramePoint> points;

        public Frame()
        {
            this.points = new List<FramePoint>();
            this.GenerateWalls();
        }

        public IReadOnlyCollection<FramePoint> Points => this.points.AsReadOnly();

        private void GenerateWalls()
        {
            //left wall
            for (int y = 1; y < Console.WindowHeight - 1; y++)
            {
                this.points.Add(new FramePoint(0, y));
                this.points.Add(new FramePoint(1, y));
            }

            //top wall
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                this.points.Add(new FramePoint(x, 0));
                this.points.Add(new FramePoint(x, 1));
            }

            //right wall
            for (int y = 1; y < Console.WindowHeight - 1; y++)
            {
                this.points.Add(new FramePoint(Console.WindowWidth - 2, y));
                this.points.Add(new FramePoint(Console.WindowWidth - 1, y));
            }

            //bottom wall
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                this.points.Add(new FramePoint(x, Console.WindowHeight - 2));
            }
        }
    }
}