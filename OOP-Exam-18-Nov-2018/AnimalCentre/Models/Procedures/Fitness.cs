namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System.Collections.Generic;

    public class Fitness : Procedure
    {
        private const int HAPPINESS_Reduce = 3;
        private const int ENERGY_Incr = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= HAPPINESS_Reduce;
            animal.Energy += ENERGY_Incr;

            if (base.procedureHistory.ContainsKey(nameof(Fitness)) == false)
            {
                base.procedureHistory.Add(nameof(Fitness), new List<IAnimal>());
            }
            procedureHistory[nameof(Fitness)].Add(animal);
        }
    }
}