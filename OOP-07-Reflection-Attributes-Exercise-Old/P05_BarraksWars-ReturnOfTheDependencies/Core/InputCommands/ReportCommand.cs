namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;

    public class ReportCommand : Command
    {
        private readonly IRepository repository;

        public ReportCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}