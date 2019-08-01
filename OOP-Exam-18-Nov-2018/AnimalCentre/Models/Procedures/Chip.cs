namespace AnimalCentre.Models.Procedures
{
    using System;
    using System.Collections.Generic;
    using AnimalCentre.Models.Contracts;

    public class Chip : Procedure
    {
        private const int HAPPINESS_Reduce = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped)
            {
                animal.ProcedureTime += procedureTime;
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.IsChipped = true;
            animal.Happiness -= HAPPINESS_Reduce;

            if (base.procedureHistory.ContainsKey(this.GetType().Name) == false)
            {
                base.procedureHistory.Add(this.GetType().Name, new List<IAnimal>());
            }
            procedureHistory[this.GetType().Name].Add(animal);
        }
    }
}