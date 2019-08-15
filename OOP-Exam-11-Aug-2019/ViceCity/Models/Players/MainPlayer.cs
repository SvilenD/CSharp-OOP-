namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int Initial_Health = 100;
        private const string Default_Name = "Tommy Vercetti";
        public MainPlayer() 
            : base(Default_Name, Initial_Health)
        {
        }
    }
}
