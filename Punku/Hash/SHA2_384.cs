using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Punku.Hash
{
	public class Sha2_384 : Hash
	{
		public Sha2_384 (string s)
		{
			byte[] data = Encoding.Default.GetBytes (s); 

			hash = new SHA384Managed ().ComputeHash (data);
		}

		public Sha2_384 (byte[] data)
		{
			hash = new SHA384Managed ().ComputeHash (data);
		}

		public static Sha2_384 FromFile (string filename)
		{
			string fullPath = Path.GetFullPath (filename);

			if (!File.Exists (fullPath))
				throw new FileNotFoundException (fullPath);

			byte[] data = File.ReadAllBytes (fullPath);

			return new Sha2_384 (data);
		}
	}
}
