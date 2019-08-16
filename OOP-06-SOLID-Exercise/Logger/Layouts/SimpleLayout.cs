namespace LoggerProject.Layouts
{
    using LoggerProject.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
