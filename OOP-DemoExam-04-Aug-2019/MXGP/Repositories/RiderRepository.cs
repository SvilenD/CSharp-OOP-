namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RiderRepository : Repository<IRider>
    {
        public RiderRepository()
        {
            this.models = new List<IRider>();
        }

        public override IRider GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}