using System;
using System.Linq;

namespace Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> FindMin = x => x.Min();

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(FindMin(array));
        }
    }
}
