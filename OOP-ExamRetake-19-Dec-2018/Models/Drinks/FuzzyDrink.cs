namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {

        public FuzzyDrink(string name, int servingSize, string brand)
            : base(name, servingSize, Prices.FuzzyDrink, brand)
        {
        }
    }
}