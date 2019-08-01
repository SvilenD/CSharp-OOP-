namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using AnimalCentre.Core;
    using AnimalCentre.Models.Contracts;

    public class Hotel : IHotel
    {
        private const int DEFAULT_Capacity = 10;

        private readonly Dictionary<string, IAnimal> animals;

        private int capacity;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            this.capacity = DEFAULT_Capacity;
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.capacity == 0)
            {
                throw new InvalidOperationException(Messages.NOT_ENOUGH_Capacity);
            }
            else if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException(String.Format(Messages.ALREADY_EXISTS_Animal, animal.Name));
            }

            this.animals.Add(animal.Name, animal);
            this.capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            var animal = animals.FirstOrDefault(a => a.Key == animalName).Value;

            if (animal == null)
            {
                throw new ArgumentException(String.Format(Messages.NOT_EXISTING_Animal, animalName));
            }

            animal.IsAdopt = true;
            animal.Owner = owner;
            this.animals.Remove(animalName);
            this.capacity++;
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => new ReadOnlyDictionary<string, IAnimal>(this.animals);
    }
}