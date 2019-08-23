namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var instance = Activator.CreateInstance(type, true);

            var methods = instance.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                var input = Console.ReadLine().Split('_');

                if (input[0]?.ToLower() == "end")
                {
                    break;
                }

                var currentMethod = methods.FirstOrDefault(m => m.Name == input[0]);

                var value = int.Parse(input[1]);

                currentMethod.Invoke(instance, new object[] { value });

                var result = instance.GetType().GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(result.GetValue(instance));
            }
        }
    }
}