using System;
using System.Linq;
using System.Reflection;

[Author("Svilen")]
public class Tracker
{
    [Author("Svilen")]
    public void PrintMethodsByAuthor()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var classes = assembly.GetTypes();
        var methods = classes.SelectMany(c => c.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));

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