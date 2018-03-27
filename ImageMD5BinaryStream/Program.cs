using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ImageMD5BinaryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock.jpeg";
            var path2 = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock2.jpeg";
            var path3 = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock3.jpeg";
            
            List<String> images = new List<string>();
            
            images.Add(path);
            images.Add(path2);
            images.Add(path3);

            foreach (var image in images)
            {
                Console.WriteLine(Hashify(image));
            }
            
            
        }

        private static string Hashify(String path)
        {
            StringBuilder sb = new StringBuilder();
            

            using (var fs = File.OpenRead(path))
            {
                using (var md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(fs);


                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.Append(data[i].ToString("x2"));
                    }
                }
            }

            return sb.ToString();
        }
    }
}