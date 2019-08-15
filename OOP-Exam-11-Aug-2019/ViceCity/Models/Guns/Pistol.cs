namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int Default_BulletsPerBarrel = 10;
        private const int Default_TotalBullets = 100;
        private const int Bullets_PerShot = 1;

        public Pistol(string name)
            : base(name, Default_BulletsPerBarrel, Default_TotalBullets)
        {
        }

        public override int Fire()
        {
            if (CanFire == false)
            {
                return 0;
            }

            this.TotalBullets -= Bullets_PerShot;

            return Bullets_PerShot;
        }
    }
}