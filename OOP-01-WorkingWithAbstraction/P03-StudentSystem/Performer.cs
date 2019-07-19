namespace StudentSystemCatalogue
{
    using System;
    using StudentSystemCatalogue.Commands;
    using StudentSystemCatalogue.Students;

    public class Performer
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;

        public Performer(CommandParser commandParser, StudentSystem studentSystem)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var command = commandParser.Parse(Console.ReadLine());
                    if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];
                        var student = studentSystem.Get(name);

                        Console.WriteLine(student);
                    }
                    else if (command.Name == "Exit")
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}