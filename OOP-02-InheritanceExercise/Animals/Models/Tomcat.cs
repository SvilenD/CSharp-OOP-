namespace Animals.Models
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
        : base(name, age, "male")
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}