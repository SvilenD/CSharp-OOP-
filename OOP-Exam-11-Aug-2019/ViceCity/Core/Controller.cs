namespace ViceCity.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private readonly List<IPlayer> civilPlayers;
        private readonly GunRepository guns;
        private readonly MainPlayer mainPlayer;
        private readonly Neighbourhood neighbourhood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.guns = new GunRepository();
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new Neighbourhood();
        }

        public string AddGun(string type, string name)
        {
            if (type == "Rifle")
            {
                this.guns.Add(new Rifle(name));
                
                return String.Format(OutputMessages.GUN_Added, name, type);
            }
            else if (type == "Pistol")
            {
                this.guns.Add(new Pistol(name));

                return String.Format(OutputMessages.GUN_Added, name, type);
            }

            return "Invalid gun type!";
        }

        public string AddGunToPlayer(string name)
        {
            var gun = this.guns.Models.FirstOrDefault();
            if (gun == null)
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var currentPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            if (currentPlayer == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            currentPlayer.GunRepository.Add(gun);
            return $"Successfully added {gun.Name} to the Civil Player: {currentPlayer.Name}";
        }

        public string AddPlayer(string name)
        {
            this.civilPlayers.Add(new CivilPlayer(name));

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var mainHealth = this.mainPlayer.LifePoints;
            var civilsCount = this.civilPlayers.Count();
            var civilsTotalHeatlh = this.civilPlayers.Sum(p => p.LifePoints);

            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (mainPlayer.LifePoints == mainHealth && civilsTotalHeatlh == this.civilPlayers.Sum(p => p.LifePoints))
            {
                return "Everything is okay!";
            }

            var civilsKilled = civilsCount - this.civilPlayers.Count();
            var result = new StringBuilder();
            result.AppendLine("A fight happened:");
            result.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
            result.AppendLine($"Tommy has killed: {civilsKilled} players!");
            result.AppendLine($"Left Civil Players: {this.civilPlayers.Count()}!");

            return result.ToString().TrimEnd();
        }
    }
}