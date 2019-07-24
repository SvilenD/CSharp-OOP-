namespace Person
{
    using System;

    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
            this.Age = base.Age ;
        }

        public new int Age
        {
            get
            {
                return base.Age;
            }
            private set
            {
                if (base.Age > 15)
                {
                    throw new ArgumentException($"Age should be less than 15.");
                }
            }
        }
    }
}