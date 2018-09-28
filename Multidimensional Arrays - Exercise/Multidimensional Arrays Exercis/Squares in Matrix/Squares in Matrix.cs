using System;
using System.Linq;
using System.Collections.Generic;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            string[,] matrix = new string[dimentions[0], dimentions[1]];

            for (int row = 0; row < dimentions[0]; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < dimentions[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int counter = 0;

            if (matrix.GetLength(0) > 1 || matrix.GetLength(1) > 1)
            {
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        string curent = matrix[row, col];
                        if (curent == matrix[row, col + 1] && curent == matrix[row + 1, col] && curent == matrix[row + 1, col + 1])
                        {
                            counter++;
                        }
                    }
                }

                Console.WriteLine(counter);

            } else {
                Console.WriteLine(0);
            }
        }
    }
}
