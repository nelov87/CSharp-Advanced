using System;
using System.Linq;
using System.Collections.Generic;

namespace Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];
            int[][] matrix = new int[rows][];

            getMatrix(matrix, rows, cols);

            int numberOfComands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfComands; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int target = int.Parse(input[0]);
                int steps = int.Parse(input[2]);
                string command = input[1];

                switch (command)
                {
                    case "down":
                        moveDown(matrix, target, steps % matrix.Length);
                        break;
                    case "left":
                        moveLeft(matrix, target, steps % matrix.Length);
                        break;
                    case "right":
                        moveRight(matrix, target, steps % matrix.Length);
                        break;
                    case "up":
                        moveUp(matrix, target, steps % matrix.Length);
                        break;
                }
            }

            int counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        rearenge(matrix, counter, row, col);
                        counter++;
                    }
                }
            }

            

        }

        private static void rearenge(int[][] matrix, int counter, int targetRow, int targetCol)
        {
            int localCounter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if(matrix[row][col] == counter)
                    {
                        Console.WriteLine($"Swap ({targetRow}, {targetCol}) with ({row}, {col})");
                        int holder = matrix[targetRow][targetCol];
                        matrix[targetRow][targetCol] = matrix[row][col];
                        matrix[row][col] = holder;
                        localCounter++;
                        return;
                    }
                    localCounter++;
                }
            }
        }

        private static void moveUp(int[][] matrix, int target, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                int firstNumber = matrix[0][target];

                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][target] = matrix[row + 1][target];
                }

                matrix[matrix.Length - 1][target] = firstNumber;
            }
        }

        private static void moveRight(int[][] matrix, int target, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                int lastNumber = matrix[target][matrix[target].Length - 1];

                for (int col = matrix[target].Length - 1; col > 0; col--)
                {
                    matrix[target][col] = matrix[target][col - 1];
                }

                matrix[target][0] = lastNumber;
            }
        }

        private static void moveLeft(int[][] matrix, int target, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                int firsNumber = matrix[target][0];

                for (int col = 0; col < matrix[target].Length - 1; col++)
                {
                    matrix[target][col] = matrix[target][col + 1];
                }

                matrix[target][matrix[target].Length - 1] = firsNumber;
            }
        }

        private static void moveDown(int[][] matrix, int target, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                int lastNumber = matrix[matrix.Length - 1][target];

                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][target] = matrix[row - 1][target];
                }

                matrix[0][target] = lastNumber;
            }
        }

        private static void getMatrix(int[][] matrix, int rows, int cols )
        {
            int counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = counter++;
                }
            }
        }

        private static void print(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

    }
}
