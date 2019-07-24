namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double DEFAULT_FuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption()
        {
            return DEFAULT_FuelConsumption;
        }
    }
}