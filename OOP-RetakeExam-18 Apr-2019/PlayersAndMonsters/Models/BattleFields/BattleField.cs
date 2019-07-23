namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsDead);
            }

            AddBeginnerBonus(attackPlayer);
            AddBeginnerBonus(enemyPlayer);

            BonusPoints(attackPlayer);
            BonusPoints(enemyPlayer);

            while (attackPlayer.IsDead == false && enemyPlayer.IsDead == false)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(x => x.DamagePoints));
            }
        }

        private void AddBeginnerBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void BonusPoints(IPlayer player)
        {
            var bonusPoints = player.CardRepository.Cards.Sum(x => x.HealthPoints);
            player.Health += bonusPoints;
        }
    }
}