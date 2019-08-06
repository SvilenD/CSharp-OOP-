namespace WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.IncreaseWeight = 0.40;
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
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}