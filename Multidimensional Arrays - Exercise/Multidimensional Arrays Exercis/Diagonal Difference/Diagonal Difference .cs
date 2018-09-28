using System;
using System.Linq;
using System.Collections.Generic;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = Int32.Parse(Console.ReadLine());
            int[,] matrix = new int[lenght, lenght];

            for (int row = 0; row < lenght; row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int col = 0; col < lenght; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[(matrix.GetLength(1) - 1) - i, i];
            }

            int sum = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(sum);

        }
    }
}
