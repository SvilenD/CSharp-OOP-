namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const int MIN_HP = 70;
        private const int MAX_HP = 100;
        private const double DEFAULT_CubicCentimeters = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, DEFAULT_CubicCentimeters)
        {
        }

        protected override void CheckIfHorsePowerIsValid(int value)
        {
            if (value < MIN_HP || value > MAX_HP)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
            }
        }
    }
}