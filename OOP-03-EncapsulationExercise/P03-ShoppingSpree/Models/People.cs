namespace ShoppingSpree.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class People : IEnumerable
    {
        private List<Person> people;

        public People(params string[] input)
        {
            this.people = GetPeople(input);
        }

        public Person FindPerson(string name)
        {
            return this.people.FirstOrDefault(p => p.Name == name);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var person in people)
            {
                yield return person;
            }
        }

        private List<Person> GetPeople(string[] input)
        {
            var people = new List<Person>();

            for (int i = 0; i < input.Length; i++)
            {
                var splittedInfo = input[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = splittedInfo[0];
                var money = decimal.Parse(splittedInfo[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }

            return people;
        }
    }
}