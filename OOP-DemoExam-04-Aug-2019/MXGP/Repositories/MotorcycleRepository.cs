namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public MotorcycleRepository()
        {
            this.models = new List<IMotorcycle>();
        }

        public override IMotorcycle GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }
    }
}