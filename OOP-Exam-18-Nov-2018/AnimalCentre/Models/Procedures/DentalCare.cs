namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System.Collections.Generic;

    public class DentalCare : Procedure
    {
        private const int HAPPINESS_Incr = 12;
        private const int ENERGY_Incr = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            animal.Happiness += HAPPINESS_Incr;
            animal.Energy += ENERGY_Incr;

            if (base.procedureHistory.ContainsKey(this.GetType().Name) == false)
            {
                base.procedureHistory.Add(this.GetType().Name, new List<IAnimal>());
            }
            procedureHistory[this.GetType().Name].Add(animal);
        }
    }
}
