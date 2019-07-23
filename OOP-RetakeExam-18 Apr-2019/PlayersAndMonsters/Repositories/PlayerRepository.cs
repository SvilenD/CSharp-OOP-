namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }
            else if (this.players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DublicatedPlayer, player.Username));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(c => c.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException(ExceptionMessages.NullPlayer);
            }

            return this.players.Remove(player);
        }
    }
}