namespace LoggerProject.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}