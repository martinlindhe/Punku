using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class Md5 : Hash
	{
		public Md5 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new MD5CryptoServiceProvider ().ComputeHash (data);
		}

		public Md5 (byte[] data)
		{
			hash = new MD5CryptoServiceProvider ().ComputeHash (data);
		}

		public static Md5 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new Md5 (data);
		}
	}
}
