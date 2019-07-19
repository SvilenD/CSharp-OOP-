namespace CarsSalesman
{
    using System.Text;

    public class Engine 
    {
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
        public string Model { get; private set; }

        public Engine(string model, int power)
            : this(model, power, GlobalConstants.displacement, GlobalConstants.efficiency)
        {
        }

        public Engine(string model, int power, int displacement)
            :this(model, power, displacement, GlobalConstants.efficiency)
        {
        }

        public Engine(string model, int power, string efficiency)
            :this(model, power, GlobalConstants.displacement, efficiency)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{GlobalConstants.offset}{this.Model}:");
            result.AppendLine($"{GlobalConstants.offset}{GlobalConstants.offset}Power: {this.power}");

            if (this.displacement == GlobalConstants.displacement)
            {
                result.AppendLine($"{GlobalConstants.offset}{GlobalConstants.offset}Displacement: n/a");
            }
            else
            {
                result.AppendLine($"{GlobalConstants.offset}{GlobalConstants.offset}Displacement: {this.displacement}");
            }

            result.AppendLine($"{GlobalConstants.offset}{GlobalConstants.offset}Efficiency: {this.efficiency}");

            return result.ToString().TrimEnd();
        }
    }
}
