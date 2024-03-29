﻿namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core;

    public class Engine : IRunnable
    {
        private readonly CommandInterpreter interpreter;
        private readonly Dependencies dependencies;

        public Engine(CommandInterpreter interpreter, Dependencies dependencies)
        {
            this.interpreter = interpreter;
            this.dependencies = dependencies;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var data = input.Split();
                    var commandName = data[0];

                    var instance = interpreter.InterpretCommand(data, commandName);
                    GetDependencies(instance);
                    var result = instance.Execute();

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void GetDependencies(IExecutable instance)
        {
            var fields = instance.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var value = typeof(Dependencies)
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f => f.Name == field.Name)
                    .GetValue(this.dependencies);

                field.SetValue(instance, value);
            }
        }
    }
}