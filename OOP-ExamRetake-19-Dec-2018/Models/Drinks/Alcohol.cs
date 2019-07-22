namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol : Drink
    {
        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, Prices.Alcohol, brand)
        {
        }
    }
}