namespace Cars
{
    using System.Text;

    public class Seat : Car, ICar
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine(Start());
            result.AppendLine(Stop());

            return result.ToString().TrimEnd();
        }
    }
}