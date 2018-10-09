using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            string path = $"../../../../files/";
            string words = "words.txt";
            string text = "text.txt";
            string result = "result.txt";
            words = Path.Combine(path, words);
            text = Path.Combine(path, text);
            result = Path.Combine(path, result);

            Dictionary<string, int> wordsHolder = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(words))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    if (!wordsHolder.ContainsKey(line))
                    {
                        wordsHolder.Add(line.ToLower(), 0);
                    }
                    line = reader.ReadLine();
                }
            }

            using (StreamReader readertext = new StreamReader(text))
            {
                //[A-Za-z]+
                string line = readertext.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    Regex regex = new Regex("[A-Za-z]+");
                    foreach (Match item in regex.Matches(line))
                    {
                        if (wordsHolder.ContainsKey(item.Value))
                        {
                            wordsHolder[item.Value] += 1;
                        }
                    }
                    line = readertext.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(result))
            {
                foreach (var word in wordsHolder.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
