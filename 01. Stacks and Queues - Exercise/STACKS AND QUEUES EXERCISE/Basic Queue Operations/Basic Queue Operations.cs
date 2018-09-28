using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            } else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            } else
            {
                int minElement = queue.Min();
                Console.WriteLine(minElement);
            }

            
        }
    }
}
