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

    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        data.AppendLine($"Class under investigation: {className}");

        foreach (var field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            data.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return this.data.ToString().Trim();
    }
}