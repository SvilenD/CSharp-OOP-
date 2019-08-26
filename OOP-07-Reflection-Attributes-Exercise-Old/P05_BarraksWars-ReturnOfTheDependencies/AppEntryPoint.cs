namespace _03BarracksFactory
{
    using Core;
    using Contracts;
    using P03_BarraksWars.Core;
    using _03BarracksFactory.Data;
    using _03BarracksFactory.Core.Factories;
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public class AppEntryPoint
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            var interpreter = new CommandInterpreter(serviceProvider);

            IRunnable engine = new Engine(interpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider; 
        }
    }
}