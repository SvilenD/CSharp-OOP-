namespace CarsSalesman
{
    using System;

    public class CarFactory
    {
        private string[] data;

        public CarFactory(string[] data)
        {
            this.data = data;
        }

        public Car Create(Engine engine)
        {
            var model = data[0];

            if (data.Length == 2)
            {
                return new Car(model, engine);
            }

            else if (data.Length == 3)
            {
                try
                {
                    var weight = int.Parse(data[2]);
                    return new Car(model, engine, weight);
                }
                catch (Exception)
                {
                    var color = data[2];
                    return new Car(model, engine, color);
                }
            }
            else if (data.Length == 4)
            {
                var weight = int.Parse(data[2]);
                string color = data[3];
                return new Car(model, engine, weight, color);
            }

            return null;
        }
    }
}