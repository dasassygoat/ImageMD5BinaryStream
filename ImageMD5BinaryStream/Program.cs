using System;
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
            
            FileStream fs = File.OpenRead(path);
            FileStream fs2 = File.OpenRead(path2);
            FileStream fs3 = File.OpenRead(path3);

            
            Console.WriteLine(Hashify(fs));
            Console.WriteLine(Hashify(fs2));
            Console.WriteLine(Hashify(fs3));
            
        }

        private static string Hashify(FileStream fs)
        {
            StringBuilder sb = new StringBuilder();
            
            using (var md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(fs);

                
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}