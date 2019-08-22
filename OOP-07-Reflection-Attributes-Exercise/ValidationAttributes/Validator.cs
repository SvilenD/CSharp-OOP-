namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes()
                                .Where(a => a is MyValidationAttribute)
                                .Select(a => (MyValidationAttribute)a);

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (attribute.IsValid(prop.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}