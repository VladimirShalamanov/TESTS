using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int r = 0;
            int c = 0;
            int countOfRods = 0;
            int countOfHoles = 1;
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = data[col];
                    if (wall[row, col] == 'V')
                    {
                        r = row;
                        c = col;
                    }
                }
            }
            string move;
            while ((move = Console.ReadLine()) != "End")
            {
                int row = r;
                int col = c;
                
                if (move == "up") row--;
                else if (move == "down") row++;
                else if (move == "left") col--;
                else if (move == "right") col++;

                if (row < 0) { row++; continue; }
                else if (row > wall.GetLength(0) - 1) { row--; continue; }
                else if (col < 0) { col++; continue; }
                else if (col > wall.GetLength(1) - 1) { col--; continue; }

                if (wall[row, col] == '-')
                {
                    wall[row, col] = 'V';
                    countOfHoles++;
                    if (move == "up") wall[row + 1, col] = '*';
                    else if (move == "down") wall[row - 1, col] = '*';
                    else if (move == "left") wall[row, col + 1] = '*';
                    else if (move == "right") wall[row, col - 1] = '*';
                }
                else if (wall[row, col] == 'R')
                {
                    row = r;
                    col = c;
                    countOfRods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[row, col] == 'C')
                {
                    countOfHoles++;
                    wall[row, col] = 'E';
                    if (move == "up") wall[row + 1, col] = '*';
                    else if (move == "down") wall[row - 1, col] = '*';
                    else if (move == "left") wall[row, col + 1] = '*';
                    else if (move == "right") wall[row, col - 1] = '*';
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                    break;
                }
                else if (wall[row, col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                    wall[row, col] = 'V';
                    if (move == "up") wall[row + 1, col] = '*';
                    else if (move == "down") wall[row - 1, col] = '*';
                    else if (move == "left") wall[row, col + 1] = '*';
                    else if (move == "right") wall[row, col - 1] = '*';
                }
                r = row;
                c = col;
            }
            if (wall[r, c] == 'V')
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                    Console.Write(wall[row, col]);
                Console.WriteLine();
            }
        }
    }
}
