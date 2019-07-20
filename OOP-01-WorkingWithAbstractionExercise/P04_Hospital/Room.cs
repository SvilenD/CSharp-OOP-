namespace Hospital
{
    using System;
    using System.Collections.Generic;

    public class Room
    {
        private const int capacity = 3;

        public Room()
        {
            this.Patients = new List<string>(capacity);
        }

        public List<string> Patients { get; }

        public void Add(string name)
        {
            if (this.Patients.Count < capacity)
            {
                Patients.Add(name);
            }
        }

        public bool HasFreeBed()
        {
            return this.Patients.Count < capacity;
        }

        public override string ToString()
        {
            return $"{string.Join(Environment.NewLine, Patients)}";
        }
    }
}