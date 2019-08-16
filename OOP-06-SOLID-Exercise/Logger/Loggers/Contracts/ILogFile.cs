namespace LoggerProject.Loggers.Contracts
{
    public interface ILogFile
    {
        long Size { get; }

        void Write(string message);
    }
}