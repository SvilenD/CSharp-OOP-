namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int Initial_Health = 50;

        public CivilPlayer(string name) 
            : base(name, Initial_Health)
        {
        }
    }
}