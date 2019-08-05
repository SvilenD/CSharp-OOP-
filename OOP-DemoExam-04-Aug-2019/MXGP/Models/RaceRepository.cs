namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }
    }
}