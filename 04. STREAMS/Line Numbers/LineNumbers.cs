using System;
using System.IO;

namespace Line_Numbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string path = "../../../../files/";
            string fileName = "text.txt";
            string outputFileName = "output.txt";
            outputFileName = Path.Combine(path, outputFileName);
            path = Path.Combine(path, fileName);
            

            using (StreamReader reader = new StreamReader(path))
            {

                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    string line = reader.ReadLine();
                    int counter = 0;

                    while (line != null)
                    { 
                        writer.WriteLine($"Line {++counter}: {line}");  
                        
                        line = reader.ReadLine();
                    }
                }
                
            }

        }
    }
}
