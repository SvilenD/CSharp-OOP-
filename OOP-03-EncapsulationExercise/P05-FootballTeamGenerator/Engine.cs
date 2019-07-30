namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using FootballTeamGenerator.Models;

    public class Engine
    {
        private const string NotExistingTeamMsg = "Team {0} does not exist.";

        private readonly Dictionary<string, Team> teams;

        public Engine()
        {
            this.teams = new Dictionary<string, Team>();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split(';');

                try
                {
                    if (input[0] == "END")
                    {
                        break;
                    }
                    else if (input[0] == "Team")
                    {
                        AddTeam(input[1]);
                    }
                    else if (input[0] == "Add")
                    {
                        AddPlayer(input);
                    }
                    else if (input[0] == "Remove")
                    {
                        RemovePlayer(input);
                    }
                    else if (input[0] == "Rating")
                    {
                        PrintRating(input[1]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void PrintRating(string teamName)
        {
            try
            {
                var team = teams[teamName];
                Console.WriteLine($"{ team.Name} - { team.Rating}");
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format(NotExistingTeamMsg, teamName));
            }
        }

        private void AddTeam(string name)
        {
            var team = new Team(name);

            if (!this.teams.ContainsKey(name) && team != null)
            {
                this.teams.Add(name, team);
            }
        }

        private void AddPlayer(string[] args)
        {
            var teamName = args[1];
            IsTeamValid(teamName);

            var name = args[2];

            var endurance = int.Parse(args[3]);
            var sprint = int.Parse(args[4]);
            var dribble = int.Parse(args[5]);
            var passing = int.Parse(args[6]);
            var shooting = int.Parse(args[7]);

            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);
            this.teams[teamName].AddPlayer(player);
        }

        private void RemovePlayer(string[] args)
        {
            var teamName = args[1];
            IsTeamValid(teamName);

            var playerName = args[2];
            teams[teamName].RemovePlayer(playerName);
        }

        private void IsTeamValid(string name)
        {
            if (teams.ContainsKey(name) == false)
            {
                throw new NullReferenceException(string.Format(NotExistingTeamMsg, name));
            }
        }
    }
}