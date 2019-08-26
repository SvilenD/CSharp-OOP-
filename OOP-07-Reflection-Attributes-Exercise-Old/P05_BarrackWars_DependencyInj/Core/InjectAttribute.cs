namespace P03_BarraksWars.Core
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}