namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const int FoodPoints = 2;
        private const char FoodSymbol = '$';

        public DollarFood(int x, int y) 
            : base(x, y, FoodPoints, FoodSymbol)
        {
        }
    }
}