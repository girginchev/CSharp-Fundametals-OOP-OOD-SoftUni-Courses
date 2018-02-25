using System;
using System.Linq;

namespace _02._Sneaking
{
    public class StartUp
    {
        public static char[][] room;
        public static int enemyRow;
        public static int enemyCol;

        public static int playerRow;
        public static int playerCol;
        public static bool isGameOver;
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            room = new char[rows][];

            enemyRow = 0;
            enemyCol = 0;

            playerRow = 0;
            playerCol = 0;

            FillRoom(rows);

            
            isGameOver = false;

            var directions = Console.ReadLine().ToCharArray();

            foreach (var direction in directions)
            {
                MoveEnemies();

                if (isGameOver)
                {
                    Print();
                    break;
                }

                int desiredRow = 0;
                int desiredCol = 0;
                switch (direction)
                {
                    case 'U':
                        desiredRow = playerRow - 1;
                        desiredCol = playerCol;
                        MovePlayer(desiredRow, desiredCol);

                        break;
                    case 'D':
                        desiredRow = playerRow + 1;
                        desiredCol = playerCol;
                        MovePlayer(desiredRow, desiredCol);
                        break;
                    case 'L':
                        desiredRow = playerRow;
                        desiredCol = playerCol - 1;
                        MovePlayer(desiredRow, desiredCol);
                        break;
                    case 'R':
                        desiredRow = playerRow;
                        desiredCol = playerCol + 1;
                        MovePlayer(desiredRow, desiredCol);
                        break;
                    case 'W':
                        desiredRow = playerRow;
                        desiredCol = playerCol;
                        MovePlayer(desiredRow, desiredCol);
                        break;
                }

                if (isGameOver)
                {
                    Print();
                    break;
                }

                room[playerRow][playerCol] = direction == 'W' ? 'S' : '.';
                playerRow = desiredRow;
                playerCol = desiredCol;
            }
        }

        public static void Print()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static void MovePlayer(int desiredRow, int desiredCol)
        {
            if (desiredRow == enemyRow)
            {
                room[enemyRow][enemyCol] = 'X';
                room[playerRow][playerCol] = '.';
                room[desiredRow][desiredCol] = 'S';
                Console.WriteLine("Nikoladze killed!");
                isGameOver = true;
                return;
            }

            if (room[desiredRow][desiredCol] == 'd' || room[desiredRow][desiredCol] == 'b')
            {
                room[playerRow][playerCol] = '.';
                room[desiredRow][desiredCol] = 'S';
                return;
            }

            if (room[desiredRow].Contains('b'))
            {
                int indexOfB = Array.IndexOf(room[desiredRow], 'b');

                if (indexOfB < desiredCol)
                {
                    Console.WriteLine($"Sam died at {desiredRow}, {desiredCol}");
                    room[playerRow][playerCol] = '.';
                    room[desiredRow][desiredCol] = 'X';
                    isGameOver = true;
                    return;
                }
            }

            if (room[desiredRow].Contains('d'))
            {
                int indexOfD = Array.IndexOf(room[desiredRow], 'd');

                if (indexOfD > desiredCol)
                {
                    Console.WriteLine($"Sam died at {desiredRow}, {desiredCol}");
                    room[playerRow][playerCol] = '.';
                    room[desiredRow][desiredCol] = 'X';
                    isGameOver = true;
                }
            }
        }

        public static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('b'))
                {
                    int index = Array.IndexOf(room[row], 'b');
                    if (index == room[row].Length - 1)
                    {
                        room[row][index] = 'd';

                        if (playerRow == row && index > playerCol)
                        {
                            Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                            room[playerRow][playerCol] = 'X';
                            isGameOver = true;
                            return;
                        }
                        continue;
                    }

                    room[row][index + 1] = 'b';
                    room[row][index] = '.';
                }

                if (room[row].Contains('d'))
                {
                    int index = Array.IndexOf(room[row], 'd');
                    if (index == 0)
                    {
                        room[row][index] = 'b';

                        if (playerRow == row && index < playerCol)
                        {
                            Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                            room[playerRow][playerCol] = 'X';
                            isGameOver = true;
                            return;
                        }
                        continue;
                    }

                    room[row][index - 1] = 'd';
                    room[row][index] = '.';
                }
            }
        }

        public static void FillRoom(int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();

                int indexCol = Array.IndexOf(room[i], 'N');
                int playerIndex = Array.IndexOf(room[i], 'S');

                if (indexCol >= 0)
                {
                    enemyRow = i;
                    enemyCol = indexCol;
                }

                if (playerIndex >= 0)
                {
                    playerRow = i;
                    playerCol = playerIndex;
                }
            }
        }
    }
}
