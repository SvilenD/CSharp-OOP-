namespace SimpleSnake
{
    using SimpleSnake.Core;
    using System;

    public static class AppExit
    {
        private const string ConfirmationMsg = " Are you sure you want to exit? Press ENTER to confirm. ";
        private const string GameOverMsg = " Game Over! Try Again? - Press SPACE to Restart. ";

        public static void Confirm()
        {
            DrawManager.WriteMsg(ConfirmationMsg);

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.Enter)
            {
                Environment.Exit(0);
            }
        }

        public static void GameOver()
        {
            DrawManager.WriteMsg(GameOverMsg);

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.Spacebar)
            {
                StartUp.Main();
            }

            Environment.Exit(0);
        }
    }
}