namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_RaceParticipants = 3;
        private readonly MotorcycleRepository motors;
        private readonly RiderRepository riders;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            this.motors = new MotorcycleRepository();
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = GetRider(riderName);

            var motor = this.motors.GetByName(motorcycleModel);
            if (motor == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motor);
            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            var rider = GetRider(riderName);

            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motors.GetByName(model) != null)
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleExists, model);
            }

            IMotorcycle motorcycle = null;
            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motors.Add(motorcycle);
            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            this.races.Add(new Race(name, laps));

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riders.GetByName(riderName) != null)
            {
                throw new ArgumentException(ExceptionMessages.RiderExists, riderName);
            }

            this.riders.Add(new Rider(riderName));
            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Riders.Count < MIN_RaceParticipants)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MIN_RaceParticipants));
            }

            var topRiders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            var result = new StringBuilder();
            result.AppendLine(String.Format(OutputMessages.RiderFirstPosition, topRiders[0].Name, raceName));
            result.AppendLine(String.Format(OutputMessages.RiderSecondPosition, topRiders[1].Name, raceName));
            result.AppendLine(String.Format(OutputMessages.RiderThirdPosition, topRiders[2].Name, raceName));

            this.races.Remove(race);
            return result.ToString().Trim();
        }

        private IRider GetRider(string riderName)
        {
            var rider = this.riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            return rider;
        }
    }
}