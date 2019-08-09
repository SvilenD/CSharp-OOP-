namespace SoftUniRestaurant.Core
{
    using System;
    using SoftUniRestaurant.Common;
    using SoftUniRestaurant.Core.Contracts;

    public class CommandInterpreter
    {
        private readonly IRestaurantController controller;

        public CommandInterpreter()
        {
            this.controller = new RestaurantController();
        }

        public string ExecuteCommand(string[] input)
        {
            try
            {
                switch (input[0])
                {
                    case "AddFood":
                        return this.controller.AddFood(input[1], input[2], decimal.Parse(input[3]));

                    case "AddDrink":
                        return this.controller.AddDrink(input[1], input[2], int.Parse(input[3]), input[4]);

                    case "AddTable":
                        return this.controller.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3]));

                    case "ReserveTable":
                        return this.controller.ReserveTable(int.Parse(input[1]));

                    case "OrderFood":
                        return this.controller.OrderFood(int.Parse(input[1]), input[2]);

                    case "OrderDrink":
                        return this.controller.OrderDrink(int.Parse(input[1]), input[2], input[3]);

                    case "LeaveTable":
                        return this.controller.LeaveTable(int.Parse(input[1]));

                    case "GetFreeTablesInfo":
                        return this.controller.GetFreeTablesInfo();

                    case "GetOccupiedTablesInfo":
                        return this.controller.GetOccupiedTablesInfo();
                    default:
                        return OutputMessages.INVALID_Command;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetSummary()
        {
            return this.controller.GetSummary();
        }
    }
}