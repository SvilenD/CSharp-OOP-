namespace HotelReservation
{
    using System;

    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int numberOfDays;
        private Season season;
        private Discount discount;

        public PriceCalculator(string[] input)
        {
            this.pricePerNight = decimal.Parse(input[0]);
            this.numberOfDays = int.Parse(input[1]);
            this.season = Enum.Parse<Season>(input[2]);
            try
            {
                this.discount = Enum.Parse<Discount>(input[3]);
            }
            catch (Exception)
            {
                this.discount = Discount.None;
            }
        }

        public decimal GetTotalPrice()
        {
            decimal price = this.pricePerNight * this.numberOfDays * (int)this.season;
            decimal discountedPrice = price - price * (int)this.discount / 100;
            return discountedPrice;
        }

        public override string ToString()
        {
            return $"{this.GetTotalPrice():F2}";
        }
    }
}