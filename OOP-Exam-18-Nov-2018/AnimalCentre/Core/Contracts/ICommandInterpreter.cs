namespace AnimalCentre.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Execute(string[] input);

        string GetHistory();
    }
}