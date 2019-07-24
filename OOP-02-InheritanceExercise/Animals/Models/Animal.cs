namespace Animals.Models
{
    using System;
    using System.Text;

    public abstract class Animal
    {
        private const string DefaultExceptionMsg = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal()
        {
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(DefaultExceptionMsg);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(DefaultExceptionMsg);
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(DefaultExceptionMsg);
                }
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.AppendLine($"{this.ProduceSound()}");

            return result.ToString().TrimEnd(); 
        }
    }
}