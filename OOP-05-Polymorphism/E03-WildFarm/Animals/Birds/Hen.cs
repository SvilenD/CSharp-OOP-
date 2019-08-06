namespace WildFarm.Animals.Birds
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.IncreaseWeight = 0.35;
        }

        protected override double IncreaseWeight { get; }

        protected override List<string> FoodsEating
        {
            get
            {
                return new List<string>() { nameof(Meat), nameof(Vegetable), nameof(Seeds), nameof(Fruit) }; 
            }
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}