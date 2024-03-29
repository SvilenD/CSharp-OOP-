﻿namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public AddCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}