namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            var gun = this.Find(model.Name);

            if (gun == null)
            {
                this.models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            var gun = this.Find(model.Name);

            if (gun == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}