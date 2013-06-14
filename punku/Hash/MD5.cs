using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
    public class MD5 : Hash
    {
        public MD5 (string s)
        {
            byte[] data = Encoding.Default.GetBytes (s); 

            hash = new MD5CryptoServiceProvider ().ComputeHash (data);
        }

        public MD5 (byte[] data)
        {
            hash = new MD5CryptoServiceProvider ().ComputeHash (data);
        }

        public static MD5 FromFile (string filename)
        {
            string fullPath = Path.GetFullPath (filename);

            if (!File.Exists (fullPath))  
                throw new FileNotFoundException (fullPath);

            byte[] data = File.ReadAllBytes (fullPath);

            return new MD5 (data);
        }
    }
}
