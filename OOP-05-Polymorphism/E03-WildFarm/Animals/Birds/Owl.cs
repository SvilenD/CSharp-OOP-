namespace WildFarm.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            this.IncreaseWeight = 0.25;
        }

        protected override double IncreaseWeight { get; }

        protected override List<string> FoodsEating
        {
            get
            {
                return new List<string> { nameof(Meat) };
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}