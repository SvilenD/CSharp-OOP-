namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities;
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
                Validator.ValidateString(value, MIN_Model_Length, ExceptionMessages.InvalidModel);

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                ValidateHP(value);
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }

        protected abstract void ValidateHP(int value);
    }
}