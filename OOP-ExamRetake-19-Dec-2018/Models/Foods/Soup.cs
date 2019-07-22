namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        public Soup(string name, decimal price)
            : base(name, (int)ServingSizes.Soup, price)
        {
        }
    }
}