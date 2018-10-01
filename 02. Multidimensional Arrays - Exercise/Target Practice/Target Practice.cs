using System;
using System.Linq;
using System.Collections.Generic;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] matrix = new char[dimentions[0]][];
            string snake = Console.ReadLine();
            int[] shootAt = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            getMatix(matrix, dimentions[1]);

            fillMatrix(matrix, snake);

            shoot(matrix, shootAt);

            colapse(matrix, dimentions);

            print(matrix);

        }

        private static void colapse(char[][] matrix, int[] dimentions)
        {
            

            for (int col = 0; col < dimentions[1]; col++)
            {
                Stack<char> stack = new Stack<char>(dimentions[0]);

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        stack.Push(matrix[row][col]);
                    }
                    if (matrix[row][col] == ' ')
                    {
                        for (int j = matrix.Length - 1; j >=0; j--)
                        {
                            if (matrix[j][col] == ' ')
                            {
                                int count = stack.Count;
                                for (int i = j; i >= 0; i--)
                                {
                                    if (count > 0)
                                    {
                                        matrix[i][col] = stack.Pop();
                                        count--;
                                    }
                                    else
                                    {
                                        matrix[i][col] = ' ';
                                        
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void shoot(char[][] matrix, int[] shootAt)
        {
            int targetRow = shootAt[0];
            int targetCol = shootAt[1];
            int radios = shootAt[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if ((Math.Pow((row - targetRow), 2) + (Math.Pow((col - targetCol), 2)) <= Math.Pow(radios, 2)))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void fillMatrix(char[][] matrix, string snake)
        {
            char[] snakeArr = snake.ToCharArray();
            bool isLeft = true;
            int counter = 0;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > snakeArr.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snakeArr[counter];
                        counter++;
                    }
                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter > snakeArr.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snakeArr[counter];
                        counter++;
                    }
                    isLeft = true;
                }
            }
        }

        private static void getMatix(char[][] matrix, int v)
        {
            for (int rows = 0; rows < matrix.Length; rows++)
            {
                matrix[rows] = new char[v];
            }
        }

        private static void print(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
