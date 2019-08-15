namespace ViceCity.Models.Guns
{
    using ViceCity.Core;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateName(value, ExceptionMessages.GunNameInvalid);

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            protected set
            {
                Validator.ValidateNumber(value, ExceptionMessages.GunBulletsNegative);

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            protected set
            {
                Validator.ValidateNumber(value, ExceptionMessages.GunTotalBulletsNegative);

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.totalBullets > 0;

        public abstract int Fire();
    }
}