namespace MXGP.Repositories
{
    using System;
    using System.Collections.Generic;
    using MXGP.Repositories.Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        protected List<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            if (this.models.Contains(model) == false)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}