namespace WildFarm.Factories
{
    using WildFarm.Animals;
    using WildFarm.Animals.Birds;
    using WildFarm.Animals.Mammals;

    public static class AnimalFactory
    {
        public static Animal Create(string[] data)
        {
            var type = data[0];
            var name = data[1];
            var weight = double.Parse(data[2]);

            if (type == nameof(Hen))
            {
                var wingSize = double.Parse(data[3]);
                return new Hen(name, weight,wingSize);
            }
            else if (type == nameof(Owl))
            {
                var wingSize = double.Parse(data[3]);
                return new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Cat))
            {
                var livingRegion = data[3];
                var breed = data[4];
                return new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                var livingRegion = data[3];
                var breed = data[4];
                return new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Mouse))
            {
                var livingRegion = data[3];
                return new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                var livingRegion = data[3];
                return new Dog(name, weight, livingRegion);
            }

            return null;
        }
    }
}