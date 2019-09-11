namespace SimpleSnake.GameObjects
{
    public class FramePoint : IPoint
    {
        private const char wallSymbol = '\u2588';

        public FramePoint(int x, int y)
        {
            this.Symbol = wallSymbol;
            this.CoordinateX = x;
            this.CoordinateY = y;
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public char Symbol { get; }
    }
}