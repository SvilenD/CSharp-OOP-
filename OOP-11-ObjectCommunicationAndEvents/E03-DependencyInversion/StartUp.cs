namespace E03_DependencyInversion
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator();
            var engine = new Engine(calculator);
            engine.Run();
        }
    }
}