﻿namespace E04_WorkForce.Models
{
    public class PartTimeEmployee : Employee
    {
        private const int DefaultWorkHours = 20;

        public PartTimeEmployee(string name) 
            : base(name, DefaultWorkHours)
        {
        }
    }
}