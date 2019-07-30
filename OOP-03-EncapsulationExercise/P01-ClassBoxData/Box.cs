namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        protected double Length
        {
            set
            {
                this.ValidateParameter(value, nameof(this.Length));

                this.length = value;
            }
        }

        protected double Width
        {
            set
            {
                this.ValidateParameter(value, nameof(this.Width));

                this.width = value;
            }
        }

        protected double Height
        {
            set
            {
                this.ValidateParameter(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (this.length * this.height + this.width * this.height);
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Surface Area - {SurfaceArea():F2}");
            result.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            result.Append($"Volume - {Volume():F2}");

            return result.ToString();
        }

        private void ValidateParameter(double value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
        }
    }
}