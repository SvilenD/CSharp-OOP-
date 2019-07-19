namespace CarsSalesman
{
    using System;

    public class EngineFactory
    {
        private string[] data;
        public EngineFactory(string[] data)
        {
            this.data = data;
        }

        public Engine Create()
        {
            var model = data[0];
            var power = int.Parse(data[1]);

            if (data.Length == 2)
            {
                return new Engine(model, power);
            }
            else if (data.Length == 3)
            {
                try
                {
                    var displacement = int.Parse(data[2]);
                    return new Engine(model, power, displacement);
                }
                catch (Exception)
                {
                    var efficiency = data[2];
                    return new Engine(model, power, efficiency);
                }
            }
            else if (data.Length == 4)
            {
                var displacement = int.Parse(data[2]);
                var efficiency = data[3];
                return new Engine(model, power, displacement, efficiency);
            }

            return null;
        }
    }
}