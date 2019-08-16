namespace LoggerProject.Layouts
{
    using System;
    using LoggerProject.Layouts.Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        private const string ERROR_msg = "Invalid Layout type";

        public ILayout Create(string type)
        {
            switch (type?.ToLower())
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException(ERROR_msg);
            }
        }
    }
}