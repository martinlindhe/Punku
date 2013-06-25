using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
    public class SHA256 : Hash
    {
        public SHA256 (string s)
        {
            byte[] data = Encoding.Default.GetBytes (s); 

            hash = new SHA256Managed ().ComputeHash (data);
        }

        public SHA256 (byte[] data)
        {
            hash = new SHA256Managed ().ComputeHash (data);
        }

        public static SHA256 FromFile (string filename)
        {
            string fullPath = Path.GetFullPath (filename);

            if (!File.Exists (fullPath))  
                throw new FileNotFoundException (fullPath);

            byte[] data = File.ReadAllBytes (fullPath);

            return new SHA256 (data);
        }
    }
}
