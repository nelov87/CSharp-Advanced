using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = "";
            string result = "";
            Queue<string> queue = new Queue<string>(); ;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                text = text + input;
            }

            Regex regexOne = new Regex(@"\[[^\[\]{}]*?([0-9]{3,})[^\[\]{}]*?\]|{[^{}\]\[]*?([0-9]{3,})[^{}\]\[]*?}");
            var matches = regexOne.Matches(text);

            foreach (var match in matches)
            {
                result += TextConverter(match);
            }

            Console.WriteLine(result);
        }

        private static string TextConverter(object match)
        {
            string numbers = match.ToString();
            string txt = "";
            int length = numbers.Length;
            Regex numRegex = new Regex(@"[0-9]+");
            numbers = numRegex.Match(numbers).ToString();
            if ((numbers.Length) % 3 == 0)
            {
                char[] charArr = numbers.ToCharArray();
                numbers = string.Join("", charArr);
                for (int i = 0; i < charArr.Length; i += 3)
                {
                    string numText = $"{charArr[i]}{charArr[i + 1]}{charArr[i + 2]}";
                    int num = int.Parse(numText) - length;
                    txt += (char)num;
                }
            }
            return txt;

        }
    }
}
