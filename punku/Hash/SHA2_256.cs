using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class SHA2_256 : Hash
	{
		public SHA2_256 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new SHA256Managed ().ComputeHash (data);
		}

		public SHA2_256 (byte[] data)
		{
			hash = new SHA256Managed ().ComputeHash (data);
		}

		public static SHA2_256 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new SHA2_256 (data);
		}
	}
}
