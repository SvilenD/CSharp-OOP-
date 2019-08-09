namespace MXGP.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Execute(string[] input);
    }
}