namespace FootballTeamGenerator.Models
{
    using System;

    public class Player
    {
        private const string InvalidStatMsg = "{0} should be between 0 and 100.";
        private const string InvalidNameMsg = "A name should not be empty.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            ValidateStats(endurance, sprint, dribble, passing, shooting);
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidNameMsg);
                }

                this.name = value;
            }
        }

        public int SkillLevel
        {
            get
            {
                return (int)Math.Round((this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0);
            }
        }

        private void ValidateStats(params int[] stats)
        {
            for (int i = 0; i < stats.Length; i++)
            {
                if (stats[i] < 0 || stats[i] > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStatMsg, (Stats)i));
                }
            }
        }
    }
}