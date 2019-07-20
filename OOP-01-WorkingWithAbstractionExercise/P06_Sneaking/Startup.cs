namespace Sneaking
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static char[][] room;
        public static Player sam;
        public static int nikoladzeRow;
        public static int nikoladzeCol;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new char[rows][];
            GetRoom();

            var moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                EnemyMovement();

                if (sam.IsDead()) 
                {
                    Console.WriteLine($"Sam died at {sam.X}, {sam.Y}");
                    break;
                }

                if (moves[i] != 'W')
                {
                    sam.Move(moves[i]);
                }

                if (sam.X == nikoladzeRow)
                {
                    room[nikoladzeRow][nikoladzeCol] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(row);
            }
        }
        
        private static void GetRoom()
        {
            for (var row = 0; row < room.Length; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();

                if (room[row].Contains('S'))
                {
                    var samRow = row;
                    var samCol = Array.IndexOf(room[row], 'S');
                    sam = new Player(samRow, samCol);
                }
                if (room[row].Contains('N'))
                {
                    nikoladzeRow = row;
                    nikoladzeCol = Array.IndexOf(room[row], 'N');
                }
            }
        }

        private static void EnemyMovement()
        {
            for (var row = 0; row < room.Length; row++)
            {
                for (var col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                        }
                        else
                        {
                            room[row][col + 1] = 'b';
                            room[row][col] = '.';
                        }

                        break;
                    }

                    if (room[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                        }
                        else
                        {
                            room[row][col - 1] = 'd';
                            room[row][col] = '.';
                        }

                        break;
                    }
                }
            }
        }
    }
}