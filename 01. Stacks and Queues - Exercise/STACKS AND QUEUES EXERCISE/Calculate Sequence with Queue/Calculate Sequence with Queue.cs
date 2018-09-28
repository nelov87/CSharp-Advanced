using System;
using System.Collections.Generic;
using System.Linq;


namespace Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var result = new List<long>();

            queue.Enqueue(input);
            result.Add(input);

            while (result.Count < 50)
            {
                long current = queue.Dequeue();
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);

                result.Add(current + 1);
                result.Add(2 * current + 1);
                result.Add(current + 2);
            }

            Console.WriteLine(String.Join(" ", result.Take(50)));
        }
    }
}
