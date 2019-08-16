namespace LoggerProject
{
    using LoggerProject.Core;

    public class StartUp
    {
        public static void Main()
        {
            var command = new CommandInterpreter();

            var engine = new Engine(command);
            engine.Run();
        }
    }
}