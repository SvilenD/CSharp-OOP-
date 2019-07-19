namespace CarsSalesman
{
    using System.Text;

    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine)
            : this(model, engine, GlobalConstants.weight, GlobalConstants.color)
        {
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, GlobalConstants.color)
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, GlobalConstants.weight, color)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.model}:");
            result.AppendLine(this.engine.ToString());

            if (this.weight == GlobalConstants.weight)
            {
                result.AppendLine($"{GlobalConstants.offset}Weight: n/a");
            }
            else
            {
                result.AppendLine($"{GlobalConstants.offset}Weight: {this.weight}");
            }

            result.AppendLine($"{GlobalConstants.offset}Color: {this.color}");

            return result.ToString().TrimEnd();
        }
    }
}