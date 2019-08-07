namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            var cardRepository = new CardRepository();

            var playerType = Type.GetType($"PlayersAndMonsters.Models.Players.{type}");

            var player = (IPlayer)Activator.CreateInstance(playerType, new object [] { cardRepository, username });

            return player;
        }
    }
}