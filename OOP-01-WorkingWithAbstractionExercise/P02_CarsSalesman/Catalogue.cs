namespace CarsSalesman
{
    using System.Collections.Generic;
    using System.Linq;

    public class Catalogue
    {
        public List<Car> Cars { get; private set; }
        public List<Engine> Engines { get; private set; }

        public Catalogue()
        {
            this.Cars = new List<Car>();
            this.Engines = new List<Engine>();
        }

        public void AddCar(string[] parameters)
        {
            var engine = Engines.FirstOrDefault(e => e.Model == parameters[1]);
            this.Cars.Add(new CarFactory(parameters).Create(engine));
        }

        public void RemoveCar(Car car)
        {
            this.Cars.Remove(car);
        }

        public void AddEngine(string[] parameters)
        {
            var engine = new EngineFactory(parameters).Create();
            this.Engines.Add(engine);
        }

        public void RemoveEngine(Engine engine)
        {
            this.Engines.Remove(engine);
        }
    }
}