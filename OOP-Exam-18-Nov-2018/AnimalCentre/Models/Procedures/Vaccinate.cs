namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System.Collections.Generic;

    public class Vaccinate : Procedure
    {
        private const int ENERGY_Reduce = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Energy -= ENERGY_Reduce;
            animal.IsVaccinated = true;

            if (base.procedureHistory.ContainsKey(nameof(Vaccinate)) == false)
            {
                base.procedureHistory.Add(nameof(Vaccinate), new List<IAnimal>());
            }
            procedureHistory[nameof(Vaccinate)].Add(animal);
        }
    }
}