namespace FamilyTree
{
    public class Person
    {
        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public Person(string data)
        {
            if (int.TryParse(data[0].ToString(), out _))
            {
                this.Birthday = data;
            }
            else
            {
                this.Name = data;
            }
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}