namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;

    public class Dependencies
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public Dependencies(UnitRepository repository, UnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
    }
}