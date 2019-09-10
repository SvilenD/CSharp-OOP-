﻿namespace SimpleSnake.GameObjects.Foods
{
    public class AsteriskFood : Food
    {
        private const int FoodPoints = -1;
        private const char FoodSymbol = '*';

        public AsteriskFood(int x, int y) 
            : base(x, y, FoodPoints, FoodSymbol)
        {
        }
    }
}