using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private readonly StringBuilder data;

    public Spy()
    {
        this.data = new StringBuilder();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);

        MethodInfo[] methods = classType.GetMethods( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var getter in methods.Where(m=>m.Name.StartsWith("get")))
        {
            data.AppendLine($"{getter.Name} will return {getter.ReturnType}"); // ReturnParameter.ParameterType

        }
        foreach (var setter in methods.Where(m => m.Name.StartsWith("set")))
        {
            data.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }
        return this.data.ToString().Trim();
    }
}