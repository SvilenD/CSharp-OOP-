namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using MXGP.Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public RiderRepository()
        {
            this.models = new List<IRider>();
        }

        public override IRider GetByName(string name)
        {
            return this.models.FirstOrDefault(r => r.Name == name);
        }
    }
}