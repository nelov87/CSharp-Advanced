using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace Tagram
{
    class Tagram
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> usersList = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] banNames = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (banNames[0].Contains("ban"))
                {
                    usersList.Remove(banNames[1]);
                }
                else
                {
                    if (!usersList.ContainsKey(tokens[0]))
                    {
                        usersList.Add(tokens[0], new Dictionary<string, int>());
                    }
                    if (!usersList[tokens[0]].ContainsKey(tokens[1]))
                    {
                        usersList[tokens[0]].Add(tokens[1], int.Parse(tokens[2]));
                    }
                    else
                    {
                        usersList[tokens[0]][tokens[1]] += int.Parse(tokens[2]);
                    }
                }

                input = Console.ReadLine();
            }

            

            foreach ( var user in usersList.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var info in user.Value)
                {
                    Console.WriteLine($"- {info.Key}: {info.Value}");
                }
            }

        }
    }
}
