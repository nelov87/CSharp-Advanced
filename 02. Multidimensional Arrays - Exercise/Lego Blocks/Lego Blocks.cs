using System;
using System.Linq;
using System.Collections.Generic;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int[][] matrix = new int[lenght][];
            int[][] matrixTwo = new int[lenght][];
            
            GetFirstBlock(lenght, matrix);
            GetSecondBlock(lenght, matrixTwo);
            GheckMatrix(matrix, matrixTwo);

        }

        private static void GheckMatrix(int[][] matrix, int[][] matrixTwo)
        {
            int lenght = matrix[0].Length + matrixTwo[0].Length;
            bool checker = true;
            int[][] result = new int[matrix.Length][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int tempLenght = matrix[row].Length + matrixTwo[row].Length;
                if (lenght == tempLenght)
                {
                    checker = true;
                    

                }
                else
                {
                    checker = false;
                    break;
                }
            }

            if (checker)
            {
                for (int roww = 0; roww < matrix.Length; roww++)
                {
                    result[roww] = new int[lenght];
                    for (int coll = 0; coll < lenght; coll++)
                    {
                        if (coll < matrix[roww].Length)
                        {
                            result[roww][coll] = matrix[roww][coll];
                        }
                        else
                        {
                            
                            result[roww][coll] = matrixTwo[roww][lenght - coll - 1];
                        }
                    }

                }
                Print(result);
            }
            else
            {
                int counter = 0;
                counter = CountCells(matrix, counter);
                counter = CountCells(matrixTwo, counter);

                Console.WriteLine($"The total number of cells is: {counter}");
            }

            ///////////////////////////////////////////////////////////////Console.WriteLine(checker);
        }

        private static int CountCells(int[][] jagedArrayToCount, int counter)
        {
            for (int row = 0; row < jagedArrayToCount.Length; row++)
            {
                counter += jagedArrayToCount[row].Length;
            }

            return counter;
        }

        private static void Print(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                string printString = string.Join(", ", row);
                Console.WriteLine($"[{printString}]");
            }
            
            
        }

        private static void GetSecondBlock(int lenght, int[][] matrixTwo)
        {
            for (int i = 0; i < lenght; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrixTwo[i] = new int[input.Length];

                for (int col = 0; col < matrixTwo[i].Length; col++)
                {
                    matrixTwo[i][col] = input[col];
                }

            }
        }

        private static void GetFirstBlock(int lenght, int[][] matrix)
        {
            for (int i = 0; i < lenght; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[i] = new int[input.Length];

                for (int col = 0; col < matrix[i].Length; col++)
                {
                    matrix[i][col] = input[col];
                }

            }
        }
    }
}
