using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
    public class SHA1 : Hash
    {
        public SHA1 (string s)
        {
            byte[] data = Encoding.Default.GetBytes (s); 

            hash = new SHA1Managed ().ComputeHash (data);
        }

        public SHA1 (byte[] data)
        {
            hash = new SHA1Managed ().ComputeHash (data);
        }

        public static SHA1 FromFile (string filename)
        {
            string fullPath = Path.GetFullPath (filename);

            if (!File.Exists (fullPath))  
                throw new FileNotFoundException (fullPath);

            byte[] data = File.ReadAllBytes (fullPath);

            return new SHA1 (data);
        }
    }
}
