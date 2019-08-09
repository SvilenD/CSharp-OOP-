namespace SoftUniRestaurant.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string ExecuteCommand(string[] input);

        string GetSummary();
    }
}
