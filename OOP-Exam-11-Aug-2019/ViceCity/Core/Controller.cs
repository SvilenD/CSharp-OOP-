﻿namespace ViceCity.Core
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
                
                return String.Format(OutputMessages.GunAdded, name, type);
            }
            else if (type == "Pistol")
            {
                this.guns.Add(new Pistol(name));

                return String.Format(OutputMessages.GunAdded, name, type);
            }

            return OutputMessages.GunInvalidType;
        }

        public string AddGunToPlayer(string name)
        {
            var gun = this.guns.Models.FirstOrDefault();

            if (gun == null)
            {
                return OutputMessages.NoGuns;
            }
            else if (name == OutputMessages.MainPlayerName)
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);
                return String.Format(OutputMessages.MainPlayerAddedGun, gun.Name);
            }

            var currentPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            if (currentPlayer == null)
            {
                return OutputMessages.PlayerNotExists;
            }

            currentPlayer.GunRepository.Add(gun);
            this.guns.Remove(gun);
            return String.Format(OutputMessages.PlayerAddedGun , gun.Name, currentPlayer.Name); 
        }

        public string AddPlayer(string name)
        {
            this.civilPlayers.Add(new CivilPlayer(name));

            return String.Format(OutputMessages.CivilPlayerAdded, name);
        }

        public string Fight()
        {
            var mainHealth = this.mainPlayer.LifePoints;
            var civilsCount = this.civilPlayers.Count();
            var civilsTotalHeatlh = this.civilPlayers.Sum(p => p.LifePoints);

            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (mainPlayer.LifePoints == mainHealth && civilsTotalHeatlh == this.civilPlayers.Sum(p => p.LifePoints))
            {
                return OutputMessages.AllOk;
            }

            var civilsKilled = civilsCount - this.civilPlayers.Count();
            var result = new StringBuilder();
            result.AppendLine(OutputMessages.Fight);
            result.AppendLine(String.Format(OutputMessages.LifePoints, mainPlayer.LifePoints));
            result.AppendLine(String.Format(OutputMessages.Killed, civilsKilled)); 
            result.AppendLine(String.Format(OutputMessages.CivilsLeft, this.civilPlayers.Count())); 

            return result.ToString().TrimEnd();
        }
    }
}