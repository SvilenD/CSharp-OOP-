namespace E04_WorkForce
{
    using E04_WorkForce.Models.Contracts;
    using System;

    public class Job
    {
        private readonly IEmployee employee;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            this.Name = name;
            this.HoursRequired = hoursRequired;
            this.employee = employee;
        }

        public string Name { get; }

        public int HoursRequired { get; private set; }

        public void Update()
        {
            this.HoursRequired -= this.employee.WorkHoursPerWeek;

            if (this.HoursRequired <= 0 )
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.JobCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler JobCompleted;

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursRequired}";
        }
    }
}