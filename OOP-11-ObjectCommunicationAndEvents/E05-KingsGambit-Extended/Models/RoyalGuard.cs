namespace E05_KingsGambit.Models
{
    public class RoyalGuard : Soldier
    {
        private const int DefaultLives = 3;

        public RoyalGuard(string name)
            : base(name, DefaultLives)
        {
        }

        public override string Response => $"Royal Guard {this.Name} is defending!";
    }
}