using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
            }
        }

        public string Draw()
        {
            var result = new StringBuilder();

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;
            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        result.Append("*");
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}