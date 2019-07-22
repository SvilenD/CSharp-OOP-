namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StackOfStrings :Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(params string[] items)
        {
            foreach (var item in items)
            {
                this.Push(item);
            }
        }
    }
}