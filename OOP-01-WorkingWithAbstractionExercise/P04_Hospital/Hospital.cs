namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public Hospital()
        {
            this.Departments = new List<Department>();
            this.Doctors = new List<Doctor>();
        }

        public List<Department> Departments { get; }

        public List<Doctor> Doctors { get; }

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public bool ContainsDepartment(string name)
        {
            return this.Departments.Any(d => d.Name == name);
        }

        public Department GetDepartment(string name)
        {
           return  Departments.FirstOrDefault(d => d.Name == name);
        }

        public void AddDoctor(Doctor doctor)
        {
            this.Doctors.Add(doctor);
        }

        public bool ContainsDoctor(string name)
        {
            return this.Doctors.Any(d => d.Name == name);
        }

        public Doctor GetDoctor(string name)
        {
            return this.Doctors.FirstOrDefault(d => d.Name == name);
        }
    }
}