using System;
using System.IO;

namespace Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string path = $"../../../../files/";
            string picture = "copyMe.png";
            string result = "copyMe-copy.png";
            picture = Path.Combine(path, picture);
            result = Path.Combine(path, result);

            using (FileStream reader = new FileStream(picture, FileMode.Open))
            {
                using (FileStream wriiter = new FileStream(result, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int byteCounter = reader.Read(buffer, 0, buffer.Length);

                        if (byteCounter == 0)
                        {
                            break;
                        }

                        wriiter.Write(buffer, 0, byteCounter);

                    }
                }
            }
        }
    }
}
