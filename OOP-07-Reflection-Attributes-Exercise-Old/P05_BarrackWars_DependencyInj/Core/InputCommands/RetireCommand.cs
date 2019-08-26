namespace P03_BarraksWars.Core.InputCommands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        private const string RetiredSuccessfully = "{0} retired!";
        [Inject]
        private readonly IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];

            try
            {
                this.repository.RemoveUnit(unitType);
                return String.Format(RetiredSuccessfully, unitType);
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
        }
    }
}