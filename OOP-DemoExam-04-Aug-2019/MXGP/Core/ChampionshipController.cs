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
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_Race_Participants_Count = 3;

        private MotorcycleRepository motorcycles;
        private RiderRepository riders;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.motorcycles = new MotorcycleRepository();
            this.riders = new RiderRepository();
            this.races = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = this.motorcycles.GetByName(motorcycleModel);
            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);
            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riders.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycles.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle = null;
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            this.motorcycles.Add(motorcycle);

            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.races.Add(race);
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riders.GetByName(riderName) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = new Rider(riderName);
            this.riders.Add(rider);

            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (race.Riders.Count < MIN_Race_Participants_Count)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MIN_Race_Participants_Count));
            }

            var topRiders = race.Riders
                .OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToArray();

            var result = new StringBuilder();
            result.AppendLine(String.Format(OutputMessages.RiderFirstPosition, topRiders[0].Name, raceName));
            result.AppendLine(String.Format(OutputMessages.RiderSecondPosition, topRiders[1].Name, raceName));
            result.AppendLine(String.Format(OutputMessages.RiderThirdPosition, topRiders[2].Name, raceName));

            races.Remove(race);// 15-th test 
            return result.ToString().TrimEnd();
        }
    }
}