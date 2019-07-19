namespace HotelReservation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var reservation = Console.ReadLine().Split();

            var price = new PriceCalculator(reservation);

            Console.WriteLine(price);
        }
    }
}