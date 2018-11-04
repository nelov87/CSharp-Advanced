using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[][] mine = new char[n][];
            int[] position = new int[2];
            int maxCoal = 0;
            int coal = 0;
            bool sss = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                FillMatrix(mine, input, i, ref position, n, ref maxCoal);
            }

            for (int turn = 0; turn < commands.Length; turn++)
            {
                MoveMiner(mine, ref position, commands[turn], ref coal, ref maxCoal, ref sss);
                if (coal == maxCoal)
                {
                    Console.WriteLine($"You collected all coals! ({position[0]}, {position[1]})");
                    break;
                }
            }

            if (!sss && coal != maxCoal)
            {
                
                   
                Console.WriteLine($"3 coals left. ({position[0]}, {position[1]})");


            }

            



        }

        private static void MoveMiner(char[][] mine, ref int[] position, string comand, ref int coal, ref int maxCoal, ref bool sss)
        {
            int row = position[0];
            int col = position[1];

            switch (comand)
            {
                case "left":

                    if (col - 1 >= 0)
                    {
                        if (mine[row][col - 1] == '*' && col - 1 >= 0)
                        {
                            mine[row][col] = '*';
                            mine[row][col - 1] = 's';
                            position[0] = row;
                            position[1] = col - 1;
                        }
                        else if (mine[row][col - 1] == 'c' && col - 1 >= 0)
                        {
                            mine[row][col] = '*';
                            coal++;
                            mine[row][col - 1] = 's';
                            position[0] = row;
                            position[1] = col - 1;

                        }
                        else if (mine[row][col - 1] == 'e' && col - 1 >= 0)
                        {
                            position[0] = row;
                            position[1] = col - 1;
                            End(position[0], position[1], ref coal, ref maxCoal);
                            sss = true;

                        }
                    }
                    break;
                case "right":
                    if (col + 1 <= mine[row].Length - 1)
                    {
                        if (mine[row][col + 1] == '*' && col + 1 <= mine[row].Length - 1)
                        {
                            mine[row][col] = '*';
                            mine[row][col + 1] = 's';
                            position[0] = row;
                            position[1] = col + 1;
                        }
                        else if (mine[row][col + 1] == 'c' && col + 1 <= mine[row].Length - 1)
                        {
                            mine[row][col] = '*';
                            coal++;
                            mine[row][col + 1] = 's';
                            position[0] = row;
                            position[1] = col + 1;
                        }
                        else if (mine[row][col + 1] == 'e' && col + 1 <= mine[row].Length - 1)
                        {
                            position[0] = row;
                            position[1] = col + 1;
                            End(position[0], position[1], ref coal, ref maxCoal);
                            sss = true;
                        }
                    }
                    
                    break;
                case "up":

                    if (row - 1 >= 0 )
                    {
                        if (mine[row - 1][col] == '*' && row - 1 >= 0)
                        {
                            mine[row][col] = '*';
                            mine[row - 1][col] = 's';
                            position[0] = row - 1;
                            position[1] = col;
                        }
                        else if (mine[row - 1][col] == 'c' && row - 1 >= 0)
                        {
                            mine[row][col] = '*';
                            coal++;
                            mine[row - 1][col] = 's';
                            position[0] = row - 1;
                            position[1] = col;
                        }
                        else if (mine[row - 1][col] == 'e' && row - 1 >= 0)
                        {
                            position[0] = row - 1;
                            position[1] = col;
                            End(position[0], position[1], ref coal, ref maxCoal);
                            sss = true;

                        }
                       
                    }
                    break;
                case "down":
                    if (row + 1 <= mine.Length - 1)
                    {
                        if (mine[row + 1][col] == '*' && row + 1 <= mine.Length - 1)
                        {
                            mine[row][col] = '*';
                            mine[row + 1][col] = 's';
                            position[0] = row + 1;
                            position[1] = col;
                        }
                        else if (mine[row + 1][col] == 'c' && row + 1 <= mine.Length - 1)
                        {
                            mine[row][col] = '*';
                            coal++;
                            mine[row + 1][col] = 's';
                            position[0] = row + 1;
                            position[1] = col;
                        }
                        else if (mine[row + 1][col] == 'e' && row + 1 <= mine.Length - 1)
                        {
                            
                            position[0] = row + 1;
                            position[1] = col;
                            End(position[0], position[1], ref coal, ref maxCoal);
                            sss = true;
                        }
                    }

                    
                    break;

            }
        }

        private static void End(int row, int col,  ref int coal, ref int maxCoal)
        {
            
            if (coal < maxCoal)
            {
                
                Console.WriteLine($"Game over! ({row}, {col})");
            }
            
        }

        private static void FillMatrix(char[][] mine, string input, int row, ref int[] startPosition, int n, ref int maxCoal)
        {
            int counter = 0;
            mine[row] = new char[n];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    mine[row][counter] = input[i];
                    if (input[i] == 's')
                    {
                        startPosition[0] = row;
                        startPosition[1] = counter;
                    }
                    if (input[i] == 'c')
                    {
                        maxCoal++;
                    }
                    counter++;
                }
            }
        }
    }
}
