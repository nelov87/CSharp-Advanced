using System;
using System.Linq;
using System.Collections.Generic;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] rowCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray();

            string[,] matix = new string[rowCol[0], rowCol[1]];

            for (int row = 0; row < rowCol[0]; row++)
            {
                for (int col = 0; col < rowCol[1]; col++)
                {
                    matix[row, col] += alphabet[row].ToString() + alphabet[row + col].ToString() + alphabet[row].ToString();
                }
            }

            for (int row = 0; row < matix.GetLength(0); row ++)
            {
                string textOfRow = "";

                for (int col = 0; col < matix.GetLength(1); col++)
                {
                    textOfRow += matix[row, col] + " ";
                }
                textOfRow = textOfRow.TrimEnd();
                Console.WriteLine(textOfRow);
            }

        }
    }
}
