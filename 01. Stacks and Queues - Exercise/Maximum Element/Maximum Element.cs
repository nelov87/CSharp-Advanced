using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int token = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            for (int i = 0; i < token; i ++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                } else if (input[0] == 2)
                {
                    stack.Pop();
                } else if (input[0] == 3)
                {
                    result.Add(stack.Max());
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
