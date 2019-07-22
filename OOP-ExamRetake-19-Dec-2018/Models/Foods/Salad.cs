namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        public Salad(string name, decimal price)
            : base(name, (int)ServingSizes.Salad, price)
        {
        }
    }
}