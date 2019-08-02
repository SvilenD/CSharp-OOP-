namespace Cars
{
    using System.Text;

    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }

        public int Battery { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString() + $" with {this.Battery} Batteries");
            result.AppendLine(Start());
            result.AppendLine(Stop());

            return result.ToString().TrimEnd();
        }
    }
}