namespace FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private const string InvalidNameMsg = "A name should not be empty.";
        private const string InvalidPlayerMsg = "Player {0} is not in {1} team.";

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameMsg);
                }

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count > 0)
                {
                    return (int)this.players.Select(p => p.SkillLevel).Average();
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException(string.Format(InvalidPlayerMsg, playerName, this.Name));
            }

            players.Remove(player);
        }
    }
}