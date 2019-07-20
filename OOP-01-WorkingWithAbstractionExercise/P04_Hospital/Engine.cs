namespace Hospital
{
    using System;
    using System.Linq;

    public class Engine
    {
        public Hospital hospital = new Hospital(); 

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "Output")
                {
                    break;
                }

                AddInputData(command);
            }

            while (true)
            {
                var args = Console.ReadLine().Split();
                if (args[0] == "End")
                {
                    break;
                }

                Console.WriteLine(GetResult(args));
            }
        }

        private string GetResult(string[] args)
        {
            if (args.Length == 1)
            {
                return $"{hospital.GetDepartment(args[0])}";
            }

            else if (args.Length == 2 && int.TryParse(args[1], out int room))
            {
                var department = hospital.GetDepartment(args[0]);

                return $"{string.Join(Environment.NewLine, department.Rooms[room].Patients.OrderBy(p => p))}";
            }

            else
            {
                var doctorName = args[0] + " " + args[1];
                var doctor = hospital.GetDoctor(doctorName);

                return $"{string.Join(Environment.NewLine, doctor.Patients.OrderBy(p => p))}";
            }
        }

        private void AddInputData(string[] input)
        {
            var departmentName = input[0];
            var doctorName = string.Join(' ', input.Skip(1).Take(2));

            if (hospital.ContainsDepartment(departmentName) == false)
            {
                hospital.AddDepartment(new Department(departmentName));
            }
            var department = hospital.GetDepartment(departmentName);

            if (hospital.ContainsDoctor(doctorName) == false)
            {
                hospital.AddDoctor(new Doctor(doctorName));
            }
            var doctor = hospital.GetDoctor(doctorName);

            if (department.IsNotFull())
            {
                var patient = input.Last();
                doctor.AddPatient(patient);
                department.AddPatient(patient);
            }
        }
    }
}