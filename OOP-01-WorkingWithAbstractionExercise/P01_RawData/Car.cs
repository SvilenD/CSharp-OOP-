namespace RawData
{
    public class Car
    {
        private readonly string model;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Cargo Cargo { get; private set; }

        public Engine Engine { get; private set; }

        public Tire[] Tires { get; private set; }

        public override string ToString()
        {
            return this.model;
        }
    }
}