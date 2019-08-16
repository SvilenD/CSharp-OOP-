namespace LoggerProject.Loggers
{
    using System.Linq;
    using System.Text;
    using LoggerProject.Loggers.Contracts;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder data;

        public LogFile()
        {
            this.data = new StringBuilder();
        }

        public long Size 
        {
            get
            {
                return this.data.ToString().Where(char.IsLetter).Sum(c => c);
            }
        }

        public void Write(string message)
        {
            this.data.Append(message);
        }
    }
}