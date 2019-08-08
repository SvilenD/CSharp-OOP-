namespace PlayersAndMonsters.Models.Players
{
    using System;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                Validator.ThrowsExceptionIfStringNullOrEmpty(value, ExceptionMessages.UsernameNullOrEmpty);

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                Validator.ThrowsExceptionIfNegativeValue(value, ExceptionMessages.NegativeHealth);
                
                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowsExceptionIfNegativeValue(damagePoints, ExceptionMessages.NegativeDamagePoints);
            
            this.Health = Math.Max(0, this.Health - damagePoints);
        }
    }
}