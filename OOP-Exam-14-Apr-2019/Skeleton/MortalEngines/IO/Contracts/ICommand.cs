namespace MortalEngines.IO.Contracts
{
    public interface ICommand
    {
        string Name { get; }
        string[] Params { get; }
    }
}