using System;

namespace SoftUniRestaurant
{
    public class OutputMessages
    {
        public const string ADD_Food = "Added {0} ({1}) with price {2:f2} to the pool";

        public const string ADD_Drink = "Added {0} ({1}) to the drink pool";

        public const string ADD_Table = "Added table number {0} in the restaurant";

        public const string NO_Table = "No available table for {0} people";

        public const string RESERVE_Table = "Table {0} has been reserved for {1} people";

        public const string TABLE_NotExists = "Could not find table with {0}";

        public const string FOOD_NotExists = "No {0} in the menu";

        public const string ORDERED_Food = "Table {0} ordered {1}";

        public const string DRINK_NotExists = "There is no {0} {1} available";

        public const string ORDERED_Drink = "Table {0} ordered {1} {2}";

        public const string LEAVE_Table = "Table: {0}{1}Bill: {2:f2}";

        public const string TOTAL_Income = "Total income: {0:f2}lv";
    }
}