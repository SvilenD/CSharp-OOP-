namespace PointInRectangle
{
    public class Rectangle
    {
        private readonly Point topLeft;
        private readonly Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Point TopLeft
        {
            get
            {
                return this.topLeft;
            }
        }

        public Point BottomRight
        {
            get
            {
                return this.bottomRight;
            }
        }

        public bool Contains(Point point)
        {
            bool isInHorizontal = this.TopLeft.X <= point.X
                && this.BottomRight.X >= point.X;

            bool isInVertical = this.TopLeft.Y <= point.Y
                && this.BottomRight.Y >= point.Y;

            return isInHorizontal && isInVertical;
        }
    }
}