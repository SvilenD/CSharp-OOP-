namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System.Collections.Generic;

    public class Play : Procedure
    {
        private const int HAPPINESS_Incr = 12;
        private const int ENERGY_Reduce = 6;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness += HAPPINESS_Incr;
            animal.Energy -= ENERGY_Reduce;

            if (base.procedureHistory.ContainsKey(nameof(Play)) == false)
            {
                base.procedureHistory.Add(nameof(Play), new List<IAnimal>());
            }
            procedureHistory[nameof(Play)].Add(animal);
        }
    }
}