namespace PlayersAndMonsters.Models.Cards
{
    using System;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CardNameNullOrEmpty);
                }
                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CardNegativeDamagePoints);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CardNegativeHealth);
                }

                this.healthPoints = value;
            }
        }
    }
}