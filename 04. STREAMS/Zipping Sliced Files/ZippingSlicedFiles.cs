using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO.Compression;

namespace Zipping_Sliced_Files
{
    class ZippingSlicedFiles
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
            //path = Path.Combine(path, "combinedFile.mp4");
            Assemble(files, path);
        }

        static void Assemble(List<string> list, string destinationDirectory)
        {
            byte[] buffer = new byte[1024];
            destinationDirectory += "combinedFile.mp4";

            using (FileStream write = new FileStream(destinationDirectory, FileMode.Create))
            {

                foreach (var file in list)
                {
                    using (GZipStream gzZip = new GZipStream(new FileStream(file + ".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        
                        while (true)
                        {
                            int bytesCount = gzZip.Read(buffer, 0, buffer.Length);
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
                long size = reader.Length / parts + reader.Length % parts;

                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string destPath = Path.Combine(destinationDirectory, $"Parth{i}.mp4");

                    

                    files.Add(destPath);

                    int readedBytes = 0;

                    using (FileStream write = new FileStream(destPath, FileMode.Create))
                    {
                        
                        int bytesCount = reader.Read(buffer, 0, buffer.Length);
                        
                        write.Write(buffer, 0, buffer.Length);
                        
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(destPath + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }

                    
                }
            }
        }
    }
}
