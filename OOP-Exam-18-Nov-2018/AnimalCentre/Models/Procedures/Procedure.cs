namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Core;
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Procedure : IProcedure
    {
        protected Dictionary<string, List<IAnimal>> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new Dictionary<string, List<IAnimal>>();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            CheckProcedureTime(animal, procedureTime);
            animal.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            StringBuilder history = new StringBuilder();
            history.AppendLine(this.GetType().Name);

            var animals = procedureHistory[this.GetType().Name]
                    .OrderBy(a => a.Name);
            foreach (var animal in animals)
            {
                history.AppendLine(animal.ToString());
            }

            return history.ToString().TrimEnd();
        }

        private void CheckProcedureTime(IAnimal animal, int time)
        {
            if (animal.ProcedureTime < time)
            {
                throw new ArgumentException(Messages.INVALID_Procedure_Msg);
            }
        }
    }
}