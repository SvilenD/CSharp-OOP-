namespace SoftUniRestaurant.Models.Tables.Models
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, Prices.OutsideTablePricePerPerson)
        {
        }
    }
}