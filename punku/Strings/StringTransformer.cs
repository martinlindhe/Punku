using System;

namespace Punku.Strings
{
	public abstract class StringTransformer
	{
		public char[] Table = new char[char.MaxValue];

		public string Transform (string s)
		{
			char[] arr = s.ToCharArray ();

			for (int i = 0; i < arr.Length; i++)
				arr [i] = Table [arr [i]];

			return new string (arr);
		}
	}
}