namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using System.Collections.Generic;
    using System.Linq;

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