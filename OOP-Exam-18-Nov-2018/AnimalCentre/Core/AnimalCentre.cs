namespace AnimalCentre.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Models.Contracts;
    using Models.Procedures;
    using Core.Contracts;

    public class AnimalCentre : IAnimalCenter
    {
        private IHotel hotel;
        private Dictionary<string, IProcedure> history;
        private Dictionary<string, List<string>> ownersAnimals;
        private AnimalFactory animalFactory;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.history = new Dictionary<string, IProcedure>();
            this.ownersAnimals = new Dictionary<string, List<string>>();
            this.animalFactory = new AnimalFactory();
            this.InitializeServices();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            hotel.Accommodate(animal);

            return String.Format(Messages.REGISTERED_Animal, name);
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["Chip"].DoService(animal, procedureTime);

            return String.Format(Messages.CHIP_ProcedureSuccessful, name);
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["Vaccinate"].DoService(animal, procedureTime);

            return String.Format(Messages.VACCINATE_ProcedureSuccessful, name);
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["Fitness"].DoService(animal, procedureTime);

            return String.Format(Messages.FITNESS_ProcedureSuccessful, name);
        }

        public string Play(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["Play"].DoService(animal, procedureTime);

            return String.Format(Messages.PLAY_ProcedureSuccessful, name, procedureTime);
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["DentalCare"].DoService(animal, procedureTime);

            return String.Format(Messages.DENTAL_ProcedureSuccessful, name);
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = GetAnimalIfExistsInTheHotel(name);

            history["NailTrim"].DoService(animal, procedureTime);

            return String.Format(Messages.NAIL_TRIM_ProcedureSuccessful, name);
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = GetAnimalIfExistsInTheHotel(animalName);

            if (this.ownersAnimals.ContainsKey(owner) == false)
            {
                this.ownersAnimals.Add(owner, new List<string>());
            }
            this.ownersAnimals[owner].Add(animalName);

            this.hotel.Adopt(animalName, owner);

            if (animal.IsChipped)
            {
                return String.Format(Messages.ADOPTED_CHIPPED_Animal, owner);
            }
            else
            {
                return String.Format(Messages.ADOPTED_NOT_CHIPPED_Animal, owner);
            }
        }

        public string History(string type)
        {
            return this.history[type].History();
        }

        public string AdobtedHistory()
        {
            var result = new StringBuilder();
            foreach (var owner in this.ownersAnimals.OrderBy(o => o.Key))
            {
                result.AppendLine($"--Owner: {owner.Key}");

                result.Append("    - Adopted animals: ");
                result.AppendLine(string.Join(" ", owner.Value));
            }
            return result.ToString().Trim();
        }

        private IAnimal GetAnimalIfExistsInTheHotel(string name)
        {
            var animal = this.hotel.Animals.FirstOrDefault(a => a.Key == name).Value;

            if (animal == null)
            {
                throw new ArgumentException(String.Format(Messages.NOT_EXISTING_Animal, name));
            }

            return animal;
        }

        private void InitializeServices()
        {
            history.Add("Chip", new Chip());
            history.Add("DentalCare", new DentalCare());
            history.Add("Fitness", new Fitness());
            history.Add("NailTrim", new NailTrim());
            history.Add("Play", new Play());
            history.Add("Vaccinate", new Vaccinate());
        }
    }
}