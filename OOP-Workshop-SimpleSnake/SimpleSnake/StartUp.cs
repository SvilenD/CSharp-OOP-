namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            var frame = new Frame();
            var snake = new Snake();
            var engine = new Engine(snake, frame);
            engine.Run();
        }
    }
}