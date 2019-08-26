namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;

    public class Dependencies
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public Dependencies()
        {
            this.repository = new UnitRepository();
            this.unitFactory = new UnitFactory();
        }
    }
}