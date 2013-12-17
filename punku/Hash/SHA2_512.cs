using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class SHA2_512 : Hash
	{
		public SHA2_512 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new SHA512Managed ().ComputeHash (data);
		}

		public SHA2_512 (byte[] data)
		{
			hash = new SHA512Managed ().ComputeHash (data);
		}

		public static SHA2_512 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new SHA2_512 (data);
		}
	}
}
