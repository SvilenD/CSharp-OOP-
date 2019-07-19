namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] coordinates = ParseInput();

            var topLeft = new Point(coordinates[0], coordinates[1]);
            var bottomRight = new Point(coordinates[2], coordinates[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);

            var pointsCount = int.Parse(Console.ReadLine());

            var points = GetPoints(pointsCount);

            foreach (var point in points)
            {
                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }

        private static Point[] GetPoints(int count)
        {
            var points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                var pointXY = ParseInput();

                points[i] = new Point(pointXY[0], pointXY[1]);
            }

            return points;
        }
    }
}