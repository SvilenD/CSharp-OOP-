namespace _03BarracksFactory
{
    using Core;
    using Contracts;
    using P03_BarraksWars.Core;
    using _03BarracksFactory.Data;
    using _03BarracksFactory.Core.Factories;

    public class AppEntryPoint
    {
        static void Main(string[] args)
        {
            var repository = new UnitRepository();
            var unitFactory = new UnitFactory();
            var interpreter = new CommandInterpreter();
            var dependencies = new Dependencies(repository, unitFactory);

            IRunnable engine = new Engine(interpreter, dependencies);
            engine.Run();
        }
    }
}