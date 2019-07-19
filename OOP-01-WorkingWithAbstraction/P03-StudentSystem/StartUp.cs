namespace StudentSystemCatalogue
{
    using StudentSystemCatalogue.Commands;
    using StudentSystemCatalogue.Students;

    public class StartUp
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();

            var performer = new Performer(commandParser, studentSystem);

            performer.Run();
        }
    }
}