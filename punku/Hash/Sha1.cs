using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class Sha1 : Hash
	{
		public Sha1 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new SHA1Managed ().ComputeHash (data);
		}

		public Sha1 (byte[] data)
		{
			hash = new SHA1Managed ().ComputeHash (data);
		}

		public static Sha1 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new Sha1 (data);
		}
	}
}
