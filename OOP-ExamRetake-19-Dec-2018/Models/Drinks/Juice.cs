namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice : Drink
    {
        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, Prices.Juice, brand)
        {
        }
    }
}