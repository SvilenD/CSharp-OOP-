namespace RawData
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Power { get; private set; }
        
        public int Speed { get; private set; }
    }
}