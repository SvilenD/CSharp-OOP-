namespace AnimalCentre.Core
{
    using Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string INVALID_Command = "Invalid command";

        private readonly AnimalCentre center;

        public CommandInterpreter()
        {
            this.center = new AnimalCentre();
        }

        public string Execute(string[] input)
        {
            switch (input[0])
            {
                case "RegisterAnimal":
                    return center.RegisterAnimal(input[1], input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]));
                case "Chip":
                    return center.Chip(input[1], int.Parse(input[2]));
                case "Adopt":
                    return center.Adopt(input[1], input[2]);
                case "DentalCare":
                    return center.DentalCare(input[1], int.Parse(input[2]));
                case "Fitness":
                    return center.Fitness(input[1], int.Parse(input[2]));
                case "History":
                    return center.History(input[1]);
                case "NailTrim":
                    return center.NailTrim(input[1], int.Parse(input[2]));
                case "Play":
                    return center.Play(input[1], int.Parse(input[2]));
                case "Vaccinate":
                    return center.Vaccinate(input[1], int.Parse(input[2]));
            }

            return INVALID_Command;
        }

        public string GetHistory()
        {
            return this.center.AdobtedHistory();
        }
    }
}