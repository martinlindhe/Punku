using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class Sha2_256 : Hash
	{
		public Sha2_256 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new SHA256Managed ().ComputeHash (data);
		}

		public Sha2_256 (byte[] data)
		{
			hash = new SHA256Managed ().ComputeHash (data);
		}

		public static Sha2_256 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new Sha2_256 (data);
		}
	}
}
