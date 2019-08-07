namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            var assembly = Assembly.GetCallingAssembly();

            var typeToCreate = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(type));

            ICard card = (ICard)Activator.CreateInstance(typeToCreate, name);
            return card;
        }
    }
}