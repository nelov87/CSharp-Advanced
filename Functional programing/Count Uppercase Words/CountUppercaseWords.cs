using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => Char.IsUpper(w[0]))
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
