namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const double Initial_CubicCentimeters = 450;
        private const int Min_HP = 70;
        private const int Max_HP = 100;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, Initial_CubicCentimeters)
        {
        }

        protected sealed override void ValidateHP(int value)
        {
            if (value < Min_HP || value > Max_HP)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
            }
        }
    }
}