namespace Sneaking
{
    using System;
    using System.Linq;

    public class Player
    {
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsDead()
        {
            if (Startup.room[this.X].Contains('b') && Array.IndexOf(Startup.room[this.X], 'b') < this.Y
                || (Startup.room[this.X].Contains('d') && Array.IndexOf(Startup.room[this.X], 'd') > this.Y))
            {
                Startup.room[this.X][this.Y] = 'X';
                return true;
            }

            return false;
        }

        public void Move(char direction)
        {
            Startup.room[this.X][this.Y] = '.';

            if (direction == 'U')
            {
                this.X--;
            }
            else if (direction == 'D')
            {
                this.X++;
            }
            else if (direction == 'L')
            {
                this.Y--;
            }
            else if (direction == 'R')
            {
                this.Y++;
            }

            Startup.room[this.X][this.Y] = 'S';
        }
    }
}