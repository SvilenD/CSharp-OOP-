namespace E04_WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        private const int DefaultWorkHours = 40;

        public StandardEmployee(string name) 
            : base(name, DefaultWorkHours)
        {
        }
    }
}