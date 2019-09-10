namespace SimpleSnake
{
    using System;

    public static class AppExit
    {
        private const string ConfirmationMsg = " Are you sure you want to exit? Press Enter to confirm. ";
        private const string GameOverMsg = " Game Over! Try Again! ";

        public static void Confirm()
        {
            WriteDetails(ConfirmationMsg);
            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void GameOver()
        {
            WriteDetails(GameOverMsg);

            Environment.Exit(0);
        }

        private static void WriteDetails(string msg)
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(70, 1);
            Console.WriteLine(msg);
        }
    }
}