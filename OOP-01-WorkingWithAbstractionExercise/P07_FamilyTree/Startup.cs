namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string mainPersonInfo = Console.ReadLine();

            List<Relationship> relations = new List<Relationship>();
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains('-'))
                {
                    var splittedInfo = input.Split(" - ");

                    var parentInfo = splittedInfo[0];
                    var childInfo = splittedInfo[1];

                    var parent = new Person(parentInfo);
                    var child = new Person(childInfo);

                    Relationship relation = new Relationship(parent, child);
                    relations.Add(relation);
                }
                else
                {
                    var splittedInfo = input.Split();
                    string name = $"{splittedInfo[0]} {splittedInfo[1]}";
                    string birthday = splittedInfo[2];

                    Person person = new Person(name, birthday);
                    people.Add(person);
                }

                input = Console.ReadLine();
            }

            Person keyPerson = people.FirstOrDefault(p => p.Name == mainPersonInfo || p.Birthday == mainPersonInfo);

            var mainPerson = new MainPerson(keyPerson);

            foreach (var relation in relations)
            {
                bool isChildByDate = relation.Child.Birthday == keyPerson.Birthday;
                bool isChildByName = relation.Child.Name == keyPerson.Name;
                bool isParentByDate = relation.Parent.Birthday == keyPerson.Birthday;
                bool isParentByName = relation.Parent.Name == keyPerson.Name;

                if (isChildByDate || isChildByName)
                {
                    Person parent = people.FirstOrDefault(p => p.Name == relation.Parent.Name
                    || p.Birthday == relation.Parent.Birthday);

                    mainPerson.Parents.Add(parent);
                }
                else if (isParentByDate || isParentByName)
                {
                    Person child = people.FirstOrDefault(p => p.Name == relation.Child.Name
                    || p.Birthday == relation.Child.Birthday);

                    mainPerson.Children.Add(child);
                }
            }

            Console.WriteLine(mainPerson);
        }
    }
}