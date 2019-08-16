namespace LoggerProject.Appenders
{
    using LoggerProject.Appenders.Contracts;
    using LoggerProject.Layouts.Contracts;

    public abstract class BaseAppender : IAppender
    {
        protected BaseAppender(ILayout layout)
        {
            this.Layout = layout;
            this.MsgCount = 0;
            this.ReportLevel = ReportLevel.INFO;
        }

        protected ILayout Layout { get; }

        public int MsgCount { get; protected set; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MsgCount}";
        }
    }
}