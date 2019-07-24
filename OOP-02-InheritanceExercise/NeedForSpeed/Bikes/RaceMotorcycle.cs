namespace NeedForSpeed.Bikes
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            :base (horsePower, fuel)
        {
        }

        public override double FuelConsumption()
        {
            return DEFAULT_FuelConsumption;
        }
    }
}