namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_Model_Length = 4;

        private string model;
        private int horsePower;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_Model_Length)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, MIN_Model_Length));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set // Should be PRIVATE SET, but acc. to softuni "smartheads" it's required to be protected. 
            {
                CheckIfHorsePowerIsValid(value);
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }

        protected abstract void CheckIfHorsePowerIsValid(int value);
    }
}