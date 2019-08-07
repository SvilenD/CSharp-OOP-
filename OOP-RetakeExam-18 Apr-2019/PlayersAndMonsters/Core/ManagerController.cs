namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private readonly CardRepository cards;
        private readonly CardFactory cardFactory;
        private readonly PlayerRepository players;
        private readonly PlayerFactory playerFactory;
        private readonly BattleField battlefield;

        public ManagerController()
        {
            this.cards = new CardRepository();
            this.cardFactory = new CardFactory();
            this.players = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.battlefield = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);

            this.players.Add(player);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);

            this.cards.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.players.Find(username);
            var card = this.cards.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, username, cardName);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.players.Find(attackUser);
            var enemy = this.players.Find(enemyUser);
            this.battlefield.Fight(attacker, enemy);

            return String.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var result = new StringBuilder();
            foreach (var player in this.players.Players)
            {
                result.AppendLine(String.Format(ConstantMessages.PlayerReportInfo,
                    player.Username, player.Health, player.CardRepository.Count));
                var cards = player.CardRepository.Cards;
                foreach (var card in cards)
                {
                    result.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }
            return result.ToString().Trim();
        }
    }
}