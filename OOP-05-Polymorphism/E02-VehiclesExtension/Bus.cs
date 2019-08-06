namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double DEFAULT_AirConConsumption = 1.4;
        public Bus(params double[] data) 
            : base(data)
        {
            this.FuelConsumption += DEFAULT_AirConConsumption;
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= DEFAULT_AirConConsumption;
            return base.Drive(distance);
        }
    }
}