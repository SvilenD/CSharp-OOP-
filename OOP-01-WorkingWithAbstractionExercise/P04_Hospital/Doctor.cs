namespace Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<string>();
        }

        public string Name { get; }

        public List<string> Patients { get; }

        public void AddPatient(string patient)
        {
            this.Patients.Add(patient);
        }
    }
}