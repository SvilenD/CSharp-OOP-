namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MainPerson
    {
        public MainPerson(Person person)
        {
            this.KeyPerson = person;
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }
        public Person KeyPerson { get; }

        public List<Person> Parents { get; private set; }

        public List<Person> Children { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.KeyPerson}");
            result.AppendLine($"Parents:");
            if (this.Parents.Any())
            {
                result.AppendLine($"{string.Join(Environment.NewLine, this.Parents)}");
            }
            result.AppendLine($"Children:");
            result.AppendLine($"{string.Join(Environment.NewLine, this.Children)}");

            return result.ToString().TrimEnd();
        }
    }
}