namespace P01_RhombusOfStars
{
    using System;

    class Program
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            GenerateUpperPart(linesCount);
            GenerateLowerPart(linesCount);
        }

        private static void GenerateUpperPart(int lines)
        {
            for (int i = 1; i <= lines; i++)
            {
                PrintRow(lines, i);
            }
        }

        private static void GenerateLowerPart(int lines)
        {
            for (int i = lines - 1; i > 0; i--)
            {
                PrintRow(lines, i);
            }
        }

        private static void PrintRow(int lines, int i)
        {
            var leftSpaces = new string(' ', lines - i);
            var stars = new char[i];
            Array.Fill(stars, '*');
            var midPart = string.Join(" ", stars);
            var rightSpaces = new string(' ', lines - i);
            var currentLine = leftSpaces + midPart + rightSpaces;

            Console.WriteLine(currentLine);
        }
    }
}