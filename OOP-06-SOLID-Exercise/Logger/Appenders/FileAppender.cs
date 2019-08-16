namespace LoggerProject.Appenders
{
    using System;
    using System.IO;

    using LoggerProject.Layouts.Contracts;
    using LoggerProject.Loggers.Contracts;

    public class FileAppender : BaseAppender
    {
        private static string FileName = $"{DateTime.Now.ToString("dd-MM-yyyy")}-log.txt";
        private static string FilePath = $"../../../{FileName}";

        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                var content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                File.AppendAllText(FilePath, content);

                this.MsgCount++;
                logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}