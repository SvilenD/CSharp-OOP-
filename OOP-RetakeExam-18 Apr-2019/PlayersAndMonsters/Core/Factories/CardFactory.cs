namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            ICard card = null;

            switch (type.ToLower())
            {
                case "magic":
                    card = new MagicCard(name);
                    break;
                case "trap":
                    card = new TrapCard(name);
                    break;
            }

            return card;
        }
    }
}