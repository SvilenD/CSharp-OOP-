namespace MXGP.Models.Riders
{
    using System;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;

    public class Rider : IRider
    {
        private const int MIN_Name_Length = 5;
        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_Name_Length)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MIN_Name_Length));
                }

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
                throw new ArgumentNullException(nameof(motorcycle), String.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}