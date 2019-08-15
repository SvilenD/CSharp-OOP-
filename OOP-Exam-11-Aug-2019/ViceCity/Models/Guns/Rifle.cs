namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int Default_BulletsPerBarrel = 50;
        private const int Default_TotalBullets = 500;
        private const int Bullets_PerShot = 5;

        public Rifle(string name)
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

            return 5;
        }
    }
}