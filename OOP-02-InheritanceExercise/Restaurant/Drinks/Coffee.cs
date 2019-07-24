namespace Restaurant.Drinks
{
    public class Coffee :HotBeverage
    {
        private const decimal DEFAULTPrice = 3.50m;
        private const int DEFAULTMilliliters = 50;

        public Coffee(string name, double caffeine)
               : base(name, DEFAULTPrice, DEFAULTMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; private set; }
    }
}