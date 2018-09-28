using System;
using System.Linq;
using System.Collections.Generic;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            int[,] matrix = new int[dimentions[0], dimentions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sum = 0;
            int maxSum = 0;
            int[,] maxMatrix = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                          matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                          matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        for (int i = 0; i < maxMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < maxMatrix.GetLength(1); j++)
                            {
                                maxMatrix[i, j] = matrix[(row + i), (col + j)];
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = 0; row < maxMatrix.GetLength(0); row++)
            {
                int[] result = new int[3];
                for (int col = 0; col < maxMatrix.GetLength(1); col++)
                {
                    result[col] = maxMatrix[row, col];
                }
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
