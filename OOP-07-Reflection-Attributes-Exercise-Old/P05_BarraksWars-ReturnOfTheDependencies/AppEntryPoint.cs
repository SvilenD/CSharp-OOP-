namespace _03BarracksFactory
{
    using Core;
    using Contracts;

    public class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRunnable engine = new Engine();
            engine.Run();
        }
    }
}