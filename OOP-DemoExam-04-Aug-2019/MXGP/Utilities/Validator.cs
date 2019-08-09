namespace MXGP.Utilities
{
    using System;

    public static class Validator
    {
        public static void ValidateString(string value, int minLength, string msg)
        {
            if (String.IsNullOrWhiteSpace(value) || value.Length < minLength)
            {
                throw new ArgumentException(String.Format(msg, value, minLength));
            }
        }
    }
}
