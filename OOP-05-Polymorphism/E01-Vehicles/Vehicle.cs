namespace Vehicles
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                Validate(value);
                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                Validate(value);
                this.fuelConsumption = value;
            }
        }

        public string Drive(double distance)
        {
            double requiredFuel = distance * this.fuelConsumption;
            try
            {
                Validate(this.fuelQuantity - requiredFuel);
                fuelQuantity -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            catch (Exception)
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double quantity)
        {
            Validate(quantity);
            this.fuelQuantity += quantity;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

        private void Validate(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}