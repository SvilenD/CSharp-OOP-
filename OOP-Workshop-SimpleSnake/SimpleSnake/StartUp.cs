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
            var drawManager = new DrawManager();
            var snake = new Snake();
            var engine = new Engine(snake, drawManager, frame);
            engine.Run();
        }
    }
}