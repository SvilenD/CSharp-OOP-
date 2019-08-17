using System;
using System.Linq;
using System.Reflection;

[Author("Svilen")]
public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var methods = assembly
            .GetTypes()
            .SelectMany(x => x.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static));

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
            {
                foreach (AuthorAttribute attribute in method.GetCustomAttributes())
                {
                    Console.WriteLine($"{method.Name} is writen by {attribute.Name}" );

                }
            }
        }
    }
}