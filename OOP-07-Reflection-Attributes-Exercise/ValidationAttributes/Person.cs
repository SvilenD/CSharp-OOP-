namespace ValidationAttributes
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        private const int MIN_Value = 12;
        private const int MAX_Value = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(MIN_Value, MAX_Value)]
        public int Age { get; private set; }
    }
}
