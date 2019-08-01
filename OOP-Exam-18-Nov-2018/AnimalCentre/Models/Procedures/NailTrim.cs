namespace AnimalCentre.Models.Procedures
{
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;

    public class NailTrim : Procedure
    {
        private const int HAPPINESS_Reduce = 7;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness -= HAPPINESS_Reduce;

            if (base.procedureHistory.ContainsKey(nameof(NailTrim)) == false)
            {
                base.procedureHistory.Add(nameof(NailTrim), new List<IAnimal>());
            }
            procedureHistory[nameof(NailTrim)].Add(animal);
        }
    }
}