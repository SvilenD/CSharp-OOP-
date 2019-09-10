namespace SimpleSnake.GameObjects
{
    public class SnakePoint : IPoint
    {
        private const char snakeSymbol = '\u25CF';

        public SnakePoint(int x, int y)
        {
            this.Symbol = snakeSymbol;
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public char Symbol { get; }
    }
}