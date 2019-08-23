namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

           // var instance = Activator.CreateInstance(type, true); //non-public

            FieldInfo[] fields = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            while (true)
            {
                var input = Console.ReadLine();

                FieldInfo[] filtered = null;
                switch (input)
                {
                    case "private":
                        filtered = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        filtered = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        filtered = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        filtered = fields;
                        break;
                    case "HARVEST":
                        return;
                }

                PrintResult(filtered);
            }
        }

        private static void PrintResult(FieldInfo[] filtered)
        {
            foreach (var field in filtered)
            {
                var accessModifier = field.Attributes.ToString().ToLower();
                if (accessModifier == "family")
                {
                    accessModifier = "protected";
                }
                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}