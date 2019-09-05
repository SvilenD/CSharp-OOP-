namespace E05_KingsGambit.Models
{
    public class Footman : Soldier
    {
        private const int DefaultLives = 2;

        public Footman(string name)
            : base(name, DefaultLives)
        {
        }

        public override string Response => $"Footman {this.Name} is panicking!";
    }
}