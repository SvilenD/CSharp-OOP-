namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Linq;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var cardType = typeof(CardFactory)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.StartsWith(type) && x.Name.EndsWith("Card")); 

            var card = (Card)Activator.CreateInstance(cardType, name );

            return card;
        }
    }
}