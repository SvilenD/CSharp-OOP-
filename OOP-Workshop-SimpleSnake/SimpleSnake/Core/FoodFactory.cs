namespace SimpleSnake.Core
{
    using System;
    using SimpleSnake.GameObjects.Foods;

    public static class FoodFactory
    {
        private static readonly Random random = new Random();

        public static Food GetFood()
        {
            Food food = null;

            var foodType = random.Next(0, 3);
            int x = random.Next(3, Console.WindowWidth - 2);
            int y = random.Next(3, Console.WindowHeight - 2);

            switch (foodType)
            {
                case 0:
                    food = new AsteriskFood(x, y);
                    break;
                case 1:
                    food = new DollarFood(x, y);
                    break;
                case 2:
                    food = new HashFood(x, y);
                    break;
            }

            return food;
        }
    }
}