namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string UsernameNullOrEmpty = "Player's username cannot be null or an empty string.";

        public const string NegativeHealth = "Player's health bonus cannot be less than zero.";

        public const string NegativeDamagePoints = "Damage points cannot be less than zero.";

        public const string CardNameNullOrEmpty = "Card's name cannot be null or an empty string.";

        public const string CardNegativeDamagePoints = "Card's damage points cannot be less than zero.";

        public const string CardNegativeHealth = "Card's HP cannot be less than zero.";

        public const string PlayerIsDead = "Player is dead!";

        public const string NullPlayer = "Player cannot be null";

        public const string DublicatedPlayer = "Player {0} already exists!";

        public const string NullCard = "Card cannot be null!";

        public const string DublicatedCard = "Card {0} already exists!";
    }
}
