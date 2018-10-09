using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> simbols = new SortedDictionary<char, int>();
            char[] arr = text.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (!simbols.ContainsKey(arr[i]))
                {
                    simbols.Add(arr[i], 1);
                }
                else
                {
                    simbols[arr[i]]++;
                }
            }

            foreach (var item in simbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
