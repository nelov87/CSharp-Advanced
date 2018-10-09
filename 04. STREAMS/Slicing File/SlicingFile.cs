using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Slicing_File
{
    class SlicingFile
    {
        static List<string> files;
        static void Main(string[] args)
        {
            files = new List<string>();
            string path = $"../../../../files/";
            string file = "sliceMe.mp4";
            file = Path.Combine(path, file);
            int n = 5;
            string destination = $"../../../../files/sliced/";
            

            Slice(file, destination, n);
            path = Path.Combine(path, "combinedFile.mp4");
            Assemble(files, path);
        }

        private static void Assemble(List<string> list, string destinationDirectory)
        {
            using (FileStream write = new FileStream(destinationDirectory, FileMode.Create))
            {
                
                foreach (var file in list)
                {
                    using (FileStream readFiles = new FileStream(file, FileMode.Open))
                    {
                        byte[] buffer = new byte[readFiles.Length];
                        while (true)
                        {
                            int bytesCount = readFiles.Read(buffer, 0, buffer.Length);
                            if (bytesCount == 0)
                            {
                                break;
                            }
                            write.Write(buffer, 0, bytesCount);
                        }
                        
                    }
                }
            }
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long size = reader.Length / parts;

                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string destPath = Path.Combine(destinationDirectory, $"Parth{i}.mp4");
                    files.Add(destPath);
                    int readedBytes = 0;
                    using (FileStream write = new FileStream(destPath, FileMode.Create))
                    {
                        while (true)
                        {
                            int bytesCount = reader.Read(buffer, 0, buffer.Length);

                            
                            if (bytesCount == 0)
                            {
                                break;
                            }
                            write.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
