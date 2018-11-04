using System;
using System.Linq;

namespace Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> AppendSir = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(AppendSir);
        }
    }
}
