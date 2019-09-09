namespace E04_WorkForce
{
    using E04_WorkForce.Models;
    using E04_WorkForce.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly List<IEmployee> employees;
        private readonly JobsList jobs;

        public Engine(JobsList jobs, List<IEmployee> employees)
        {
            this.jobs = jobs;
            this.employees = employees;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if (command == "Pass Week")
                {
                    for (int i = 0; i < jobs.Count; i++)
                    {
                        jobs[i].Update();
                    }
                }
                else if (command == "Status")
                {
                    foreach (var job in jobs)
                    {
                        Console.WriteLine(job);
                    }
                }
                else if (command.StartsWith("Job"))
                {
                    CreateJob(command);
                }
                else if (command.Contains("Employee"))
                {
                    CreateEmployee(command);
                }
            }

        }

        private void CreateJob(string command)
        {
            var jobArgs = command.Split();
            var jobName = jobArgs[1];
            var hoursRequired = int.Parse(jobArgs[2]);
            var employeeName = jobArgs[3];

            var employee = this.employees.Find(e=>e.Name == employeeName);

            var job = new Job(jobName, hoursRequired, employee);
            this.jobs.Add(job);
            job.JobCompleted += jobs.RemoveCompleted;
        }

        private void CreateEmployee(string command)
        {
            var employeeArgs = command.Split();
            var employeeType = employeeArgs[0];
            var employeeName = employeeArgs[1];

            IEmployee employee = null;
            switch (employeeType)
            {
                case "StandardEmployee":
                    employee = new StandardEmployee(employeeName);
                    break;
                case "PartTimeEmployee":
                    employee = new PartTimeEmployee(employeeName);
                    break;
            }

            this.employees.Add(employee);
        }
    }
}