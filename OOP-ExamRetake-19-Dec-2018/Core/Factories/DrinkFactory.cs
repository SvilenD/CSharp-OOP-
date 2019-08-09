namespace SoftUniRestaurant.Core.Factories
{
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Drinks.Contracts;

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            switch (type.ToLower())
            {
                case "alcohol":
                    return new Alcohol(name, servingSize, brand);

                case "fuzzydrink":
                    return new FuzzyDrink(name, servingSize, brand);

                case "juice":
                    return new Juice(name, servingSize, brand);

                case "water":
                    return new Water(name, servingSize, brand);
            }

            return null;
        }

    }
}