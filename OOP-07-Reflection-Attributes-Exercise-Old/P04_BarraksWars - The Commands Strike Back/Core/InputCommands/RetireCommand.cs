namespace P03_BarraksWars.Core.InputCommands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        private const string RetiredSuccessfully = "{0} retired!";
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];

            try
            {
                this.Repository.RemoveUnit(unitType);
                return String.Format(RetiredSuccessfully, unitType);
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
    }
}