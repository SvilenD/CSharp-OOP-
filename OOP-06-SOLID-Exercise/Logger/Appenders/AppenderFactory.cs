namespace LoggerProject.Appenders
{
    using System;

    using LoggerProject.Appenders.Contracts;
    using LoggerProject.Layouts.Contracts;
    using LoggerProject.Loggers;

    public class AppenderFactory : IAppenderFactory
    {
        private const string ERROR_msg = "Invalid Appender type";

        public IAppender Create(string type, ILayout layout)
        {
            switch (type?.ToLower())
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException(ERROR_msg);
            }
        }
    }
}