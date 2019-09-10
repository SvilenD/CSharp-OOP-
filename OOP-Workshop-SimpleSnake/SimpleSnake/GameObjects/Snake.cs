namespace SimpleSnake.GameObjects
{
    using SimpleSnake.Enums;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private const int SnakeLength = 6;
        private const int DefaultX = 30;
        private const int DefaultY = 30;
        private readonly Queue<SnakePoint> body;

        public Snake()
        {
            this.body = new Queue<SnakePoint>(SnakeLength);
            this.Direction = Direction.Right;
            this.GenerateBody();
        }

        public Direction Direction { get; set; }

        public IReadOnlyCollection<IPoint> Body => this.body;

        public void Move()
        {
            this.body.Dequeue();
            this.body.Enqueue(GetHead());
        }

        public void Eat()
        {
            this.body.Enqueue(GetHead());
        }

        public SnakePoint GetHead()
        {
            SnakePoint oldHead = this.body.Last();

            int newX = oldHead.CoordinateX;
            int newY = oldHead.CoordinateY;
            switch (this.Direction)
            {
                case Direction.Right:
                    newX++; break;
                case Direction.Left:
                    newX--; break;
                case Direction.Down:
                    newY++; break;
                case Direction.Up:
                    newY--; break;
            }

            return new SnakePoint(newX, newY);
        }

        private void GenerateBody()
        {
            int x = DefaultX;
            int y = DefaultY;

            for (int i = 0; i < SnakeLength; i++)
            {
                var point = new SnakePoint(x, y);
                this.body.Enqueue(point);
                x++;
            }
        }
    }
}