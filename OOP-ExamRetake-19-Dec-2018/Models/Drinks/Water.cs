namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, Prices.Water, brand)
        {
        }
    }
}