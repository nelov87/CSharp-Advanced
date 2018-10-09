using System;
using System.IO;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string path = "../../../../files/";
            string fileName = "text.txt";
            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine($"{line}");
                        
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
             

        }
    }
}
