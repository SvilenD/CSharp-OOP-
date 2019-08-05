namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;

    public class Race : IRace
    {
        private const int MIN_Name_Length = 5;
        private const int MIN_Laps = 2;

        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
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

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < MIN_Laps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_Laps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), (String.Format(ExceptionMessages.RiderInvalid)));
            }
            else if (rider.CanParticipate == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if (this.riders.Any(r => r.Name == rider.Name))
            {
                throw new ArgumentNullException(nameof(rider), String.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}