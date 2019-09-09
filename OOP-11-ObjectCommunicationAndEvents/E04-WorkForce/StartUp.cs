namespace E04_WorkForce
{
    using E04_WorkForce.Models.Contracts;
    using System.Collections.Generic;

    public static class StartUp
    {
        public static void Main()
        {
            var employees = new List<IEmployee>();
            var jobs = new JobsList();
            var engine = new Engine(jobs, employees);
            engine.Run();
        }
    }
}