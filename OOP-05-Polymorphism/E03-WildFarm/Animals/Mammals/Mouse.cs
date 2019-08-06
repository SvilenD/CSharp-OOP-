namespace WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            this.IncreaseWeight = 0.10;
        }

        protected override double IncreaseWeight { get; }

        protected  override List<string> FoodsEating
        {
            get
            {
                return new List<string> { nameof(Fruit), nameof(Vegetable) };
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}