using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;

namespace ImageMD5BinaryStream
{
    static class Program
    {
        
        
        static void Main(string[] args)
        {
            const string path = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock.jpeg";
            const string path2 = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock2.jpeg";
            const string path3 = "/home/bryan/Dropbox/src/ImageMD5BinaryStream/ImageMD5BinaryStream/images/lock3.jpeg";

            var images = new List<string> {path, path2, path3};
            var hashes = new List<string>();

            foreach (var image in images)
            {
                string hash;
                hashes.Add(hash = Hashify(image));
                WriteLine(hash);
            }

            WriteLine( IsHashEqual(hashes) ? "Match Found" : "No Match");
        }

        private static string Hashify(string path)
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

        private static bool IsHashEqual(IReadOnlyCollection<string> hashList)
        {
            return hashList.Distinct().Count() != hashList.Count;
        }
    }
}