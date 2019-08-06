namespace WildFarm.Animals.Mammals
{
    using WildFarm.Animals;

    public abstract class Mammal :Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }
    }
}