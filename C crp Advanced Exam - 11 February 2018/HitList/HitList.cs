using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, string>> hitList = new Dictionary<string, Dictionary<string, string>>();

            while (input != "end transmissions")
            {
                string[] name = input.Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] data = name[1].Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach ( string kvp in data)
                {
                    string[] keyAndValues = kvp.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (!hitList.ContainsKey(name[0]))
                    {
                        hitList.Add(name[0], new Dictionary<string, string>());
                    }
                    if (!hitList[name[0]].ContainsKey(keyAndValues[0]))
                    {
                        hitList[name[0]].Add(keyAndValues[0], keyAndValues[1]);
                    }
                    else
                    {
                        hitList[name[0]][keyAndValues[0]] = keyAndValues[1];
                    }
                }

                input = Console.ReadLine();
            }

            string[] killOrder = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string nameToKill = killOrder[1];

            int indexes = GaderIndexex(nameToKill, hitList);
            Console.WriteLine($"Info on {nameToKill}:");
            GaderInfo(nameToKill, hitList);
            Console.WriteLine($"Info index: {indexes}");
            if (indexes < index)
            {
                Console.WriteLine($"Need {index - indexes} more info.");
            }
            else
            {
                Console.WriteLine("Proceed");
            }
        }

        private static void GaderInfo(string nameToKill, Dictionary<string, Dictionary<string, string>> hitList)
        {
            foreach (var bag in hitList[nameToKill].OrderBy(n => n.Key))
            {
                Console.WriteLine($"---{bag.Key}: {bag.Value}");
            }
        }

        private static int GaderIndexex(string name, Dictionary<string, Dictionary<string, string>> hitList)
        {
            int value = 0;
            foreach (var bag in hitList[name])
            {
                value += bag.Key.Length;
                value += bag.Value.Length;
            }

            return value;
        }
    }
}
