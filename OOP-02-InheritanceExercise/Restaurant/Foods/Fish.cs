namespace Restaurant.Foods
{
    public class Fish : MainDish
    {
        private const int DEFAULTGrams = 22;

        public Fish(string name, decimal price)
            : base(name, price, DEFAULTGrams)
        {
        }
    }
}