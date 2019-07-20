namespace Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        private readonly List<Department> departments;
        private readonly List<Doctor> doctors;

        public Hospital()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public IReadOnlyCollection<Department> Departments
        {
            get
            {
                return this.departments.AsReadOnly();
            }
        }

        public IReadOnlyCollection<Doctor> Doctors
        {
            get
            {
                return this.doctors.AsReadOnly();
            }
        }

        public void AddDepartment(Department department)
        {
            this.departments.Add(department);
        }

        public bool ContainsDepartment(string name)
        {
            return this.departments.Any(d => d.Name == name);
        }

        public Department GetDepartment(string name)
        {
            return this.departments.FirstOrDefault(d => d.Name == name);
        }

        public void AddDoctor(Doctor doctor)
        {
            this.doctors.Add(doctor);
        }

        public bool ContainsDoctor(string name)
        {
            return this.doctors.Any(d => d.Name == name);
        }

        public Doctor GetDoctor(string name)
        {
            return this.doctors.FirstOrDefault(d => d.Name == name);
        }
    }
}