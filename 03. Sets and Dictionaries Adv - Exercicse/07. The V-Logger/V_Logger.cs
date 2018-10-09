using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    class V_Logger
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, User> vLogger = new Dictionary<string, User>();

            while (input[0]!= "Statistics")
            {
                if (input[1] == "joined")
                {
                    if (!vLogger.ContainsKey(input[0]))
                    {
                        List<string> f1 = new List<string>();
                        List<string> f2 = new List<string>();
                        User user = new User
                        {
                            Followers = f1,
                            Following = f2
                        };
                        vLogger.Add(input[0], user);
                    }
                    
                } else if (input[1] == "followed")
                {
                    if (vLogger.ContainsKey(input[0]) && vLogger.ContainsKey(input[2]))
                    {
                        if (input[0] != input[2] && !vLogger[input[2]].Followers.Contains(input[0]))
                        {
                            vLogger[input[2]].Followers.Add(input[0]);
                            vLogger[input[0]].Following.Add(input[2]);
                        }
                    }
                    
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            vLogger = vLogger.OrderByDescending(k => k.Value.Followers.Count).ThenBy(kk => kk.Value.Following.Count).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            int counter = 0;
            foreach (var user in vLogger)
            {
                Console.WriteLine($"{++counter}. {user.Key} : {user.Value.Followers.Count} followers, {user.Value.Following.Count} following");
                if (user.Value.Followers.Count > 1)
                {
                    user.Value.Followers.Sort();
                    foreach (var follower in user.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
            
        }
    }

    class User
    {
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
    }
}


// EmilConrad joined The V-Logger
// Saffrona followed EmilConra
