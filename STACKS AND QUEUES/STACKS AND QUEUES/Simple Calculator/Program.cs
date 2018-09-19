using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] values = input.Split(' ');
            Stack<string> stack = new Stack<string>(values.Reverse());
            int result = 0;

            while(stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (operand)
                {
                    case "+":
                        second = first + second;
                        stack.Push(second.ToString());
                        break;
                    case "-":
                        second = first - second;
                        stack.Push(second.ToString());
                        break;
                }
                
            }
            result = int.Parse(stack.Pop());
            Console.WriteLine(result);

        }
    }
}
