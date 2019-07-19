namespace GreedyTimes
{
    using System;
    using GreedyTimes.Models;

    public class Engine
    {
        private Bag bag;
        private long capacity;

        public Engine()
        {
            this.capacity = long.Parse(Console.ReadLine());
            this.bag = new Bag(capacity);
        }

        public void Run()
        {
            var safeContent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < safeContent.Length; i += 2)
            {
                var name = safeContent[i];
                var quantity = long.Parse(safeContent[i + 1]);

                AddItem(name, quantity);
            }

            Console.WriteLine(bag);
        }

        private void AddItem(string name, long quantity)
        {
            if (quantity > bag.Capacity)
            {
                return;
            }
            else if (name.Length == 3)
            {
                bag.AddCash(new Cash(name, quantity));
            }
            else if (name.ToLower() == "gold")
            {
                bag.AddGold(quantity);
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                bag.AddGem(new Gem(name, quantity));
            }
        }
    }
}