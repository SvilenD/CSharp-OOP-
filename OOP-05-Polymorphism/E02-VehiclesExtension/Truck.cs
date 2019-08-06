namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double CONST_SummerFuelConsumpIncrease = 1.6;
        private const double CONST_RefuelLostAmount = 0.05;

        public Truck(params double[] data) 
            : base(data)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + CONST_SummerFuelConsumpIncrease;
        }

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
            this.FuelQuantity -= quantity * CONST_RefuelLostAmount;
        }
    }
}