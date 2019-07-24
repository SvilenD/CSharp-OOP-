namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public void Drive(double kilometers)
        {
            if (this.Fuel >= kilometers * FuelConsumption())
            {
                this.Fuel -= kilometers * FuelConsumption();
            }
        }

        protected double DefaultFuelConsumption => DEFAULT_FuelConsumption;

        public virtual double FuelConsumption() =>  DEFAULT_FuelConsumption;
    }
}