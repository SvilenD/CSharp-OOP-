namespace RawData
{
    public class Tire
    {
        private double pressure;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.Age = age;
        }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }

            set
            {
                if (value >= 0)
                {
                    this.pressure = value;
                }
            }
        }

        public int Age { get; private set; }
    }
}