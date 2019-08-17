using System;
using System.Reflection;
using System.Text;

public class Spy
{
    private readonly StringBuilder data;

    public Spy()
    {
        this.data = new StringBuilder();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        data.AppendLine($"All Private Methods of Class: {investigatedClass}")
            .AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            data.AppendLine(method.Name);
        }

        return data.ToString().Trim();
    }
}