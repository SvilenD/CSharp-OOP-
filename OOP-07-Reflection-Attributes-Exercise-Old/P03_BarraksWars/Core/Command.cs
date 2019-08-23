
namespace P03_BarraksWars.Core
{
    using System;
    using _03BarracksFactory.Contracts;
    public abstract class Command : IExecutable
    {
        public abstract string Execute();
    }
}
