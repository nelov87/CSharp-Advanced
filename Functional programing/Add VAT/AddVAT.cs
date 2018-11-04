using System;
using System.Linq;

namespace Add_VAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.20)
                .ToArray();

            foreach (var n in numbers)
            {
                Console.WriteLine($"{n:f2}");
            }
        }
    }
}
