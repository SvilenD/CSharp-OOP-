namespace SoftUniRestaurant.Models.Tables.Models
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, Prices.InsideTablePricePerPerson)
        {
        }
    }
}