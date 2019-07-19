namespace RawData
{
    using System.Linq;

    public class Assembly
    {
        private const int tiresCount = 4;

        private readonly string model;
        private readonly string[] engineData;
        private readonly string[] cargoData;
        private readonly string[] tiresData;

        public Assembly(string[] data)
        {
            this.model = data[0];
            this.engineData = data.Skip(1).Take(2).ToArray();
            this.cargoData = data.Skip(3).Take(2).ToArray();
            this.tiresData = data.Skip(5).ToArray();
        }

        public Car CreateCar()
        {
            return new Car(this.model, this.GetEngine(), this.GetCargo(), this.GetTires());
        }

        private Engine GetEngine()
        {
            var speed = int.Parse(this.engineData[0]);
            var power = int.Parse(this.engineData[1]);

            return new Engine(speed, power);
        }

        private Cargo GetCargo()
        {
            var weight = int.Parse(this.cargoData[0]);
            var type = this.cargoData[1];

            return new Cargo(weight, type);
        }

        private Tire[] GetTires()
        {
            var tires = new Tire[tiresCount];
            int index = 0;

            for (int i = 0; i < 8; i += 2)
            {
                var pressure = double.Parse(this.tiresData[i]);
                var age = int.Parse(this.tiresData[i + 1]);
                var tire = new Tire(pressure, age);
                tires[index] = tire;

                index++;
            }

            return tires;
        }
    }
}