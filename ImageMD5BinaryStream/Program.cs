using System;
using System.IO;
using System.Net;
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

            using (var md5Hash = MD5.Create())
            {

                byte[] data = md5Hash.ComputeHash(fs);
                byte[] data2 = md5Hash.ComputeHash(fs2);
                byte[] data3 = md5Hash.ComputeHash(fs3);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                
                StringBuilder sb2 = new StringBuilder();
                for (int i = 0; i < data2.Length; i++)
                {
                    sb2.Append(data2[i].ToString("x2"));
                }
                
                StringBuilder sb3 = new StringBuilder();
                for (int i = 0; i < data3.Length; i++)
                {
                    sb2.Append(data3[i].ToString("x2"));
                }
                Console.WriteLine(sb.ToString());
                Console.WriteLine(sb2.ToString());
                Console.WriteLine(sb3.ToString());
            }
            
        }
    }
}