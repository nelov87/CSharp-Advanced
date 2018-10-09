using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];
                string[] clotes = input[1].Split(",").ToArray();
                
                if (!wardobe.ContainsKey(color))
                {
                    wardobe.Add(color,new Dictionary<string, int>());
                    foreach (var item in clotes)
                    {
                        if (!wardobe[color].ContainsKey(item))
                        {
                            wardobe[color].Add(item, 1);
                        }
                        else
                        {
                            wardobe[color][item]++;
                        }
                    }
                }
                else
                {
                    foreach (var item in clotes)
                    {
                        if (!wardobe[color].ContainsKey(item))
                        {
                            wardobe[color].Add(item, 1);
                        }
                        else
                        {
                            wardobe[color][item]++;
                        }
                    }
                }

            }

            string[] search = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string found = " (found!)";
            foreach (var colorInWadrobe in wardobe)
            {
                Console.WriteLine($"{colorInWadrobe.Key} clothes:");
                foreach (var cloth in colorInWadrobe.Value)
                {
                    
                    if (search[0] == colorInWadrobe.Key && search[1] == cloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}{found}");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                    
                }
            }
        }
    }
}
