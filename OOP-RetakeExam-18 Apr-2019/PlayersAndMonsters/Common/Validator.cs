namespace PlayersAndMonsters.Common
{
    using System;

    public static class Validator
    {
        public static void ThrowsExceptionIfNegativeValue(int value, string msg)
        {
            if (value < 0)
            {
                throw new ArgumentException(msg);
            }
        }

        public static void ThrowsExceptionIfStringNullOrEmpty(string value, string msg)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException(msg);
            }
        }
    }
}
