namespace SimpleSnake.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;

    public class Engine
    {
        private const sbyte InitialCounter = 100;
        private readonly Snake snake;
        private readonly DrawManager drawManager;
        private readonly List<Food> foods;
        private readonly Frame frame;
        private sbyte level;
        private sbyte sleepTime;
        private sbyte counter;
        private int score;

        public Engine(Snake snake, DrawManager drawManager, Frame frame)
        {
            this.snake = snake;
            this.drawManager = drawManager;
            this.foods = new List<Food>();
            this.level = 1;
            this.sleepTime = sbyte.MaxValue;
            this.counter = InitialCounter;
            this.score = 0;
            this.frame = frame;
        }

        public void Run()
        {
            this.drawManager.DrawSet(this.frame.Points);
            InitializeFood();

            while (true)
            {
                this.drawManager.DrawSet(this.snake.Body);
                var pointToClear = this.snake.Body.First();
                this.drawManager.ClearPoint(pointToClear);

                this.drawManager.WriteScore(this.score, this.level);
                if (this.counter == 0)
                {
                    this.counter = InitialCounter;
                    this.sleepTime--;
                    this.level++;
                    InitializeFood();
                }

                if (Console.KeyAvailable)
                {
                    var keyInput = Console.ReadKey();
                    if (keyInput.Key.Equals(ConsoleKey.Escape))
                    {
                        AppExit.Confirm();
                        this.drawManager.DrawSet(this.frame.Points);
                    }
                    GetDirection(keyInput);
                }
                Thread.Sleep(sleepTime);

                CheckForFood();
                CheckForCollision();
                this.snake.Move();
                
                this.counter--;
            }
        }

        private void CheckForCollision()
        {
            var head = this.snake.GetHead();
            if (this.frame.Points.Any(x=>x.CoordinateX == head.CoordinateX && x.CoordinateY ==head.CoordinateY))
            {
                AppExit.GameOver();
            }
        }

        private void CheckForFood()
        {
            var head = this.snake.GetHead();
            var foodToEat = this.foods.FirstOrDefault(f => f.CoordinateX == head.CoordinateX && f.CoordinateY == head.CoordinateY);
            if (foodToEat != null)
            {
                this.score += foodToEat.Points;
                this.snake.Eat();
                this.foods.Remove(foodToEat);
            }
        }

        private void InitializeFood()
        {
            for (int i = 0; i < 2; i++)
            {
                var food = FoodFactory.GetFood();
                this.foods.Add(food);
                this.drawManager.DrawFood(food);
            }
        }

        private void GetDirection(ConsoleKeyInfo keyInput)
        {
            switch (keyInput.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (snake.Direction != Direction.Right)
                    {
                        this.snake.Direction = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (snake.Direction != Direction.Left)
                    {
                        this.snake.Direction = Direction.Right;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (snake.Direction != Direction.Down)
                    {
                        this.snake.Direction = Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (snake.Direction != Direction.Up)
                    {
                        this.snake.Direction = Direction.Down;
                    }
                    break;
            }
        }
    }
}