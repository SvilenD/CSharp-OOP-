namespace GreedyTimes.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private bool printGold; // 10-ти тест иска принт и при добавено 0 злато
        private bool printGems;
        private bool printCash;

        private Dictionary<string, Gem> gemsBag;
        private Dictionary<string, Cash> cashBag;

        private long goldAmount;
        private long gemsAmount;
        private long cashAmount;

        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.gemsBag = new Dictionary<string, Gem>();
            this.cashBag = new Dictionary<string, Cash>();
            this.goldAmount = 0;
            this.gemsAmount = 0;
            this.cashAmount = 0;
            this.printGold = false;
            this.printGems = false;
            this.printCash = false;
        }

        public long Capacity { get; private set; }

        public void AddGem(Gem gem)
        {
            if (this.goldAmount >= this.gemsAmount + gem.Quantity && this.gemsAmount + gem.Quantity >= this.cashAmount)
            {
                this.Capacity -= gem.Quantity;
                this.printGems = true;
                this.gemsAmount += gem.Quantity;

                if (this.gemsBag.ContainsKey(gem.Name) == false)
                {
                    this.gemsBag.Add(gem.Name, gem);
                }
                else
                {
                    gemsBag[gem.Name].Quantity += gem.Quantity;
                }
            }
        }

        public void AddCash(Cash cash)
        {
            if (this.goldAmount >= this.gemsAmount && this.gemsAmount >= this.cashAmount + cash.Quantity)
            {
                this.Capacity -= cash.Quantity;
                this.printCash = true;
                this.cashAmount += cash.Quantity;

                if (this.cashBag.ContainsKey(cash.Name) == false)
                {
                    this.cashBag.Add(cash.Name, cash);
                }
                else
                {
                    cashBag[cash.Name].Quantity += cash.Quantity;
                }
            }
        }

        public void AddGold(long quantity)
        {
            if (this.goldAmount + quantity >= this.gemsAmount && this.gemsAmount >= this.cashAmount)
            {
                this.Capacity -= quantity;
                this.printGold = true;
                this.goldAmount += quantity;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (printGold)
            {
                result.AppendLine($"<Gold> ${this.goldAmount}");
                result.AppendLine($"##Gold - {goldAmount}");
            }
            if (printGems)
            {
                result.AppendLine($"<Gem> ${this.gemsAmount}");
                foreach (var gem in this.gemsBag.OrderByDescending(g => g.Key).ThenBy(g => g.Value.Quantity))
                {
                    result.AppendLine($"##{gem.Key} - {gem.Value.Quantity}");
                }
            }
            if (printCash)
            {
                result.AppendLine($"<Cash> ${this.cashAmount}");
                foreach (var cash in this.cashBag.OrderByDescending(c => c.Key).ThenBy(c => c.Value.Quantity))
                {
                    result.AppendLine($"##{cash.Key} - {cash.Value.Quantity}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}