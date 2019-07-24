namespace Restaurant.Foods
{
    public class Cake : Dessert
    {
        private const decimal DEFAULTPrice = 5m;
        private const double DEFAULTGrams = 250;
        private const double DEFAULTCalories = 1000;

        public Cake(string name)
            : base(name, DEFAULTPrice, DEFAULTGrams, DEFAULTCalories)
        {
        }
    }
}