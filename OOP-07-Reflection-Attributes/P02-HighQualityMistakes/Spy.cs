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

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        foreach (var field in fieldsInfo)
        {
            data.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("get")))
        {
            data.AppendLine($"{method.Name} have to be public!");
        }

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        foreach (var method in nonPublicMethods.Where(m=>m.Name.StartsWith("set")))
        {
            data.AppendLine($"{method.Name} have to be private!");
        }

        return data.ToString().Trim();
    }
}