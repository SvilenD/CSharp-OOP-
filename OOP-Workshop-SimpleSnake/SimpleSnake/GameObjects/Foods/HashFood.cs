namespace SimpleSnake.GameObjects.Foods
{
    public class HashFood : Food
    {
        private const int FoodPoints = 3;
        private const char FoodSymbol = '#';

        public HashFood(int x, int y) 
            : base(x, y, FoodPoints, FoodSymbol)
        {
        }
    }
}
