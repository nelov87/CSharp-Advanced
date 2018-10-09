using System;
using System.Linq;
using System.Collections.Generic;

namespace UniqueUsernames

{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> names = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int counter = 1;
                if (!names.ContainsKey(input))
                {
                    names.Add(input, counter);
                    counter++;
                }
            }

            foreach (var name in names)
            {
                Console.WriteLine(name.Key);
            }
        }
    }
}
