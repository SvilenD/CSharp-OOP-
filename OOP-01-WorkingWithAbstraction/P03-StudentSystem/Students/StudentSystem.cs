namespace StudentSystemCatalogue.Students
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> studentsData;
        public StudentSystem()
        {
            this.studentsData = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (this.studentsData.ContainsKey(name) == false)
            {
                var student = new Student(name, age, grade);
                this.studentsData[name] = student;
            }
        }

        public Student Get (string name)
        {
            if (this.studentsData.ContainsKey(name) == false)
            {
                throw new InvalidOperationException($"Student with name {name} is not found.");
            }

            return this.studentsData[name];
        }
    }
}