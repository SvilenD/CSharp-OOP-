namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double CONST_SummerFuelConsumpIncrease = 0.9;

        public Car(params double[] data) 
            : base(data)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + CONST_SummerFuelConsumpIncrease;
        }
    }
}