using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.Models;

namespace SoftUniRestaurant.Core.Factories
{
    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            if (type.ToLower() == "inside")
            {
                return new InsideTable(tableNumber, capacity);
            }
            else if (type.ToLower() == "outside")
            {
               return new OutsideTable(tableNumber, capacity);
            }

            return null;
        }
    }
}