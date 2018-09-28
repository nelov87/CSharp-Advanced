using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] charArr = input.Split(" ").ToArray();
            Stack<string> stack = new Stack<string>(charArr);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }


        }
    }
}
