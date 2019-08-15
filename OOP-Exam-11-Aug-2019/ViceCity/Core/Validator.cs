namespace ViceCity.Core
{
    using System;

    public static class Validator
    {
        public static void ValidateName(string name, string msg)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(msg);
            }
        }

        public static void ValidateNumber(int value, string msg)
        {
            if (value < 0)
            {
                throw new ArgumentException(msg);
            }
        }
    }
}