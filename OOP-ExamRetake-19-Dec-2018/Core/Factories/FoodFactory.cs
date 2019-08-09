namespace SoftUniRestaurant.Core.Factories
{
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            switch (type.ToLower())
            {
                case "dessert":
                    return new Dessert(name, price);
                    
                case "maincourse":
                    return new MainCourse(name, price);
                case "salad":
                    return new Salad(name, price);
                case "soup":
                    return  new Soup(name, price);
            }

            return null;
        }
    }
}
