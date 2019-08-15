namespace ViceCity.Models.Neghbourhoods
{
    using System.Linq;
    using System.Collections.Generic;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class Neighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (civilPlayers.Count > 0 && mainPlayer.GunRepository.Models.Count > 0)
            {
                var currentPlayer = civilPlayers.First();
                var gun = mainPlayer.GunRepository.Models.First(g => g.CanFire);

                while (currentPlayer.IsAlive)
                {
                    int lifePointsTaken = gun.Fire();

                    if (gun.TotalBullets <= 0)
                    {
                        mainPlayer.GunRepository.Remove(gun);
                    }

                    currentPlayer.TakeLifePoints(lifePointsTaken);
                }

                if (currentPlayer.IsAlive == false)
                {
                    civilPlayers.Remove(currentPlayer);
                }
            }

            if (civilPlayers.Count > 0)
            {
                while (civilPlayers.Any(x => x.GunRepository.Models.Count > 0) && mainPlayer.IsAlive)
                {
                    var currentPlayer = civilPlayers.First();
                    var gun = currentPlayer.GunRepository.Models.First(g => g.CanFire);

                    int lifePointsTaken = gun.Fire();

                    if (gun.TotalBullets <= 0)
                    {
                        currentPlayer.GunRepository.Remove(gun);
                    }

                    mainPlayer.TakeLifePoints(lifePointsTaken);
                }
            }
        }
    }
}