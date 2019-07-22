namespace SoftUniRestaurant.Models.Foods
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price)
            : base(name, (int)ServingSizes.Dessert, price)
        {
        }
    }
}