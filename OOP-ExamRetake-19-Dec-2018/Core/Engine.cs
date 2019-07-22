namespace SoftUniRestaurant.Core
{
    using System;
    using SoftUniRestaurant.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly IRestaurantController controller;

        public Engine()
        {
            this.controller = new RestaurantController();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }
                try
                {
                    switch (input[0])
                    {
                        case "AddFood":
                            Console.WriteLine(this.controller.AddFood(input[1], input[2], decimal.Parse(input[3]))); 
                            break;

                        case "AddDrink":
                            Console.WriteLine(this.controller.AddDrink(input[1], input[2], int.Parse(input[3]), input[4]));
                            break;

                        case "AddTable":
                            Console.WriteLine(this.controller.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3])));
                            break;

                        case "ReserveTable":
                            Console.WriteLine(this.controller.ReserveTable(int.Parse(input[1])));
                            break;

                        case "OrderFood":
                            Console.WriteLine(this.controller.OrderFood(int.Parse(input[1]), input[2]));
                            break;

                        case "OrderDrink":
                            Console.WriteLine(this.controller.OrderDrink(int.Parse(input[1]), input[2], input[3]));
                            break;

                        case "LeaveTable":
                            Console.WriteLine(this.controller.LeaveTable(int.Parse(input[1])));
                            break;

                        case "GetFreeTablesInfo":
                            Console.WriteLine(this.controller.GetFreeTablesInfo());
                            break;

                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(this.controller.GetOccupiedTablesInfo());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.controller.GetSummary());
        }
    }
}