using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<string> revers = new Stack<string>();

            for (int i = 0; i < text.Length; i++)
            {
                revers.Push(text[i].ToString());
            }
            string reversedString = "";
            int counter = revers.Count;
            for (int j = 0; j < counter; j++)
            {
                reversedString += revers.Pop();
            }
            Console.WriteLine(reversedString);
            Console.ReadLine();
        }
    }
}
