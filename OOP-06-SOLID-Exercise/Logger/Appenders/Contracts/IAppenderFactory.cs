using LoggerProject.Layouts.Contracts;

namespace LoggerProject.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender Create(string type, ILayout layout);
    }
}