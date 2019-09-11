namespace SimpleSnake.GameObjects.Foods
{
    public class VenomFood : Food
    {
        private const int FoodPoints = -1;
        private const char FoodSymbol = '\u0298';

        public VenomFood(int x, int y)
            : base(x, y, FoodPoints, FoodSymbol)
        {
        }
    }
}