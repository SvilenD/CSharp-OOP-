namespace WildFarm.Factories
{
    using WildFarm.Foods;

    public static class FoodFactory
    {
        public static Food Create(string[] data)
        {
            var type = data[0];
            var quantity = int.Parse(data[1]);

            if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(quantity);
            }
            else if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }

            return null;
        }
    }
}