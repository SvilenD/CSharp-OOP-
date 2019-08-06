namespace AnimalCentre.Core
{
    using Core.Contracts;
    using Models.Animals;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    return new Cat(name, energy, happiness, procedureTime);
                case "Dog":
                    return new Dog(name, energy, happiness, procedureTime);
                case "Lion":
                    return new Lion(name, energy, happiness, procedureTime);
                case "Pig":
                    return new Pig(name, energy, happiness, procedureTime);
            }

            return null;
        }
    }
}