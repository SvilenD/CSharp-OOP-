namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var currentType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

            if (currentType == null)
            {
                throw new ArgumentException("Invalid unit type.");
            }

            var instance = (IUnit)Activator.CreateInstance(currentType);

            return instance;
        }
    }
}