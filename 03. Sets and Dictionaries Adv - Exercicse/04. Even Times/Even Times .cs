using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes 
{
    class EvenTimes 
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < lenght; i++)
            {
                int input = Int32.Parse(Console.ReadLine());
                if (!pairs.ContainsKey(input))
                {
                    pairs.Add(input, 1);
                }
                else
                {
                    pairs[input]++;
                }
            }

            foreach (var element in pairs)
            {
                if (element.Value % 2 == 0)
                {
                    Console.WriteLine(element.Key);
                    break;
                }
            }
        }
    }
}
