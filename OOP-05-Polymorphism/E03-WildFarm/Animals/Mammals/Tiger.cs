namespace WildFarm.Animals.Mammals
{
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.IncreaseWeight = 1;
        }

        protected override List<string> FoodsEating
        {
            get
            {
                return new List<string> { nameof(Meat)};
            }
        }

        protected override double IncreaseWeight { get; }


        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}