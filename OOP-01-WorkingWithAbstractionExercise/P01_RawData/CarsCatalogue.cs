namespace RawData
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarsCatalogue
    {
        private readonly List<Car> cars;

        public CarsCatalogue()
        {
            this.cars = new List<Car>();
        }

        public void Add(Car car)
        {
            this.cars.Add(car);
        }

        public void Remove(Car car)
        {
            this.cars.Remove(car);
        }

        public List<Car> Filter(string type)
        {
            if (type == "fragile")
            {
                return this.cars
                    .Where(c => c.Cargo.Type == type && c.Tires
                    .Any(t => t.Pressure < 1))
                    .ToList();
            }
            else if (type == "flamable")
            {
                return this.cars
                    .Where(c => c.Cargo.Type == type && c.Engine.Power > 250)
                    .ToList();
            }

            return null;
        }
    }
}