namespace ViceCity.Models.Players
{
    using ViceCity.Core;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private readonly GunRepository gunRepository;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateName(value, ExceptionMessages.PlayerNameInvalid);

                this.name = value;
            }
        }

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            private set
            {
                Validator.ValidateNumber(value, ExceptionMessages.PlayerLifePointsNegative);

                this.lifePoints = value;
            }
        }

        public bool IsAlive => this.lifePoints > 0;

        public IRepository<IGun> GunRepository => this.gunRepository;

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints < points)
            {
                this.LifePoints = 0;
            }
            else
            {
                this.LifePoints -= points;
            }
        }
    }
}