namespace VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        private const string DEFAULT_TooBigFuelAmount = "Cannot fit {0} fuel in the tank";
        private const string DEFAULT_NegativeNumber = "Fuel must be a positive number";
        private const string DEFAULT_TravelledDistance = "{0} travelled {1} km";
        private const string DEFAULT_NotEnoughFuel = "{0} needs refueling";

        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(params double[] data)
        {
            this.tankCapacity = data[2];
            this.FuelQuantity = data[0];
            this.FuelConsumption = data[1];
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
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
                this.fuelConsumption = value;
            }
        }

        public virtual string Drive(double distance)
        {
            double requiredFuel = distance * this.FuelConsumption;
            try
            {
                Validate(this.fuelQuantity - requiredFuel);
                fuelQuantity -= requiredFuel;

                return String.Format(DEFAULT_TravelledDistance, this.GetType().Name, distance);
            }
            catch (Exception)
            {
                return String.Format(DEFAULT_NotEnoughFuel, this.GetType().Name);
            }
        }

        //public virtual void Refuel(double quantity)
        //{
        //    Validate(quantity);
        //    this.fuelQuantity += quantity;
        //}
        public virtual void Refuel(double fuel)
        {
            double newFuel = this.FuelQuantity + fuel;

            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (newFuel > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }

        private void Validate(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(DEFAULT_NegativeNumber);
            }
            else if (value > this.tankCapacity)
            {
                throw new ArgumentException(String.Format(DEFAULT_TooBigFuelAmount, value));
            }
        }
    }
}