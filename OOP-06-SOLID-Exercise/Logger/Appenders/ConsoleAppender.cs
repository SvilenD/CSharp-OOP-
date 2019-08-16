namespace LoggerProject.Appenders
{
    using System;
    using LoggerProject.Layouts.Contracts;

    public class ConsoleAppender : BaseAppender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
                this.MsgCount++;
            }
        }
    }
}