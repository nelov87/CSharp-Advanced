using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Data_Transfer
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int mb = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                mb += IsValid(input); 
            }

            Console.WriteLine($"Total data transferred: {mb}MB");
            

        }

        private static int IsValid(string input)
        {
            string patt = "(s:[A-Za-z\\S].+).(r:[A-Za-z\\S].*)(m--\"[A-Za-z\\s]*\")";
            MatchCollection regex = Regex.Matches(input, patt);
            int dataMB = 0;

            foreach (Match match in regex)
            {
                string sender = match.Groups[1].ToString();
                sender = sender.Trim(';');

                string resiver = match.Groups[2].ToString();
                resiver = resiver.Trim(';');

                string message = match.Groups[3].ToString();
                message = message.Trim(';');


                

                if (!sender.Contains(";") && !resiver.Contains(";"))
                {
                    
                    MatchCollection regexForSender = Regex.Matches(sender, @"[\d]");
                    foreach (Match n in regexForSender)
                    {
                        dataMB += int.Parse(n.ToString());
                    }
                    MatchCollection regexStringSender = Regex.Matches(sender, @"[A-Za-z\s]*");
                    sender = "";
                    foreach (Match s in regexStringSender)
                    {
                        
                        sender += s;
                    }
                    sender = sender.TrimStart('s');

                    MatchCollection regexForResiver = Regex.Matches(resiver, @"[\d]");
                    foreach (Match n in regexForResiver)
                    {
                        dataMB += int.Parse(n.ToString());
                    }
                    MatchCollection regexStringResiver = Regex.Matches(resiver, @"[A-Za-z\s]*");
                    resiver = "";
                    foreach (Match s in regexStringResiver)
                    {
                        
                        resiver += s;
                    }
                    resiver = resiver.TrimStart('r');

                    MatchCollection regexForMessage = Regex.Matches(message, @"[\d]");
                    foreach (Match n in regexForMessage)
                    {
                        dataMB += int.Parse(n.ToString());
                    }
                    MatchCollection regexStringMessege = Regex.Matches(message, @"[A-Za-z\s]*");
                    message = "";
                    foreach (Match s in regexStringMessege)
                    {
                        
                        message += s;
                    }
                    message = message.TrimStart('m');

                    Print(sender, resiver, message);
                }
            }
            return dataMB;
        }

        private static void Print(string sender, string resiver, string message)
        {
            Console.WriteLine($"{sender} says \"{message}\" to { resiver}");
        }
    }
}
