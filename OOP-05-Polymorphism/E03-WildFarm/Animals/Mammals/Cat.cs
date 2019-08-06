namespace WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.IncreaseWeight = 0.30;
        }

        protected override double IncreaseWeight { get; }
        protected override List<string> FoodsEating
        {
            get
            {
                return new List<string> { nameof(Meat), nameof(Vegetable) };
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}