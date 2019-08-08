namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;

    using Contracts;
    using Common;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Models.BattleFields.Contracts;
    using Models.BattleFields;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IPlayerFactory playerFactory;
        private readonly ICardRepository cardRepository;
        private readonly ICardFactory cardFactory;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cardRepository = new CardRepository();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return String.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var report = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                report.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Cards.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    report.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                report.AppendLine("###");
            }

            return report.ToString().Trim();
        }
    }
}