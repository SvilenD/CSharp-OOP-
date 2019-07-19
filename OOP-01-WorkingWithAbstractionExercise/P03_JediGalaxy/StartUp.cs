namespace JediGalaxy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static long sum = 0;
        static void Main()
        {
            int[] dimensions = GetArray(Console.ReadLine());

            int[,] matrix = new Matrix(dimensions).Create();

            string command = Console.ReadLine();


            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = GetArray(command);

                int[] evilCoordinates = GetArray(Console.ReadLine());

                MoveEvil(evilCoordinates, matrix);

                MoveIvo(ivoCoordinates, matrix);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }


        private static void MoveIvo(int[] ivoCoordinates, int[,] matrix)
        {
            int ivoX = ivoCoordinates[0];
            int ivoY = ivoCoordinates[1];

            while (ivoX >= 0 && ivoY < matrix.GetLength(1))
            {
                if (IsInMatrix(matrix, ivoX, ivoY))
                {
                    sum += matrix[ivoX, ivoY];
                }
                ivoY++;
                ivoX--;
            }
        }

        private static void MoveEvil(int[] evilCoordinates, int[,] matrix)
        {
            int evilX = evilCoordinates[0];
            int evilY = evilCoordinates[1];

            while (evilX >= 0 && evilY >= 0)
            {
                if (IsInMatrix(matrix, evilX, evilY))
                {
                    matrix[evilX, evilY] = 0;
                }
                evilX--;
                evilY--;
            }
        }

        private static int[] GetArray(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
        }

        public static bool IsInMatrix(int[,] matrix, int x, int y)
        {
            if (x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}