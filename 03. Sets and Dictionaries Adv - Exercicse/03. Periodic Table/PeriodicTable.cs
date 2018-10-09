using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int lenght = Int32.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < lenght; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var element in input)
                {
                    set.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", set));

        }
    }
}
