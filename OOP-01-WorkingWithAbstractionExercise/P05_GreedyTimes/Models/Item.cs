namespace GreedyTimes.Models
{
    public abstract class Item
    {
        protected Item(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; }

        public long Quantity { get; set; }
    }
}