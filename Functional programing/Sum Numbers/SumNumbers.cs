using System;
using System.Linq;

namespace Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseMy)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
            Console.ReadLine();
        }

        public static Func<string, int> ParseMy = n => Int32.Parse(n);
    }
}
