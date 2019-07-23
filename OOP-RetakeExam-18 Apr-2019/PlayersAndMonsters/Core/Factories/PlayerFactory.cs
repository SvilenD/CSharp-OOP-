namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var cardRepository = new CardRepository();
            IPlayer player = null;

            switch (type.ToLower())
            {
                case "beginner":
                    player = new Beginner(cardRepository, username);
                    break;

                case "advanced":
                    player = new Advanced(cardRepository, username);
                    break;
            }

            return player;
        }
    }
}