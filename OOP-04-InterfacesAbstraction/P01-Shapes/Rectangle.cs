namespace Shapes
{
    using System;
    using System.Text;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
            }
        }

        public string Draw()
        {
            var result = new StringBuilder();

            DrawLine(this.width, '*', '*', result);
            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ', result);
            }

            DrawLine(this.width, '*', '*', result);

            return result.ToString();
        }

        private string DrawLine(int width, char end, char mid, StringBuilder result)
        {
            result.Append(end);
            for (int i = 1; i < width - 1; ++i)
            {
                result.Append(mid);
            }

            result.AppendLine(end.ToString());
            return result.ToString();
        }
    }
}