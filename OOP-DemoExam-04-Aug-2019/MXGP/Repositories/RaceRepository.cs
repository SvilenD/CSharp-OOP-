namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using MXGP.Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(r => r.Name == name);
        }
    }
}