namespace MXGP.Models.Riders
{
    using System;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using MXGP.Utilities;

    public class Rider : IRider
    {
        private const int MIN_Name_Length = 5;
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateString(value, MIN_Name_Length, ExceptionMessages.InvalidName);

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
