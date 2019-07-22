namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private readonly Random random = new Random();

        public string RandomString()
        {
            var index = random.Next(0, this.Count);

            var item = this[index];
            this.Remove(item);

            return item;
        }
    }
}