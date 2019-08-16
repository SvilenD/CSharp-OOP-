namespace LoggerProject.Core
{
    using System;
    using System.Collections.Generic;

    using LoggerProject.Appenders;
    using LoggerProject.Appenders.Contracts;
    using LoggerProject.Core.Contracts;
    using LoggerProject.Layouts;
    using LoggerProject.Layouts.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICollection<IAppender> appenders;

        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];

            var layout = this.layoutFactory.Create(layoutType);
            var appender = this.appenderFactory.Create(appenderType, layout);

            try
            {
                appender.ReportLevel = Enum.Parse<ReportLevel>(args[2].ToUpper());
            }
            catch (Exception)
            {
                // add if necessary
            }
            finally
            {
                appenders.Add(appender);
            }
        }

        public void AddReport(string[] args)
        {
            var reportLevel = Enum.Parse<ReportLevel>(args[0]);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}