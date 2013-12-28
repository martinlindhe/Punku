using System;

namespace Punku.Strings
{
	/** 
	 * Transform english text to inverted form (a=z, b=y, c=x etc)
	 */
	public class Invert
	{
		public char[] Table = new char[char.MaxValue];

		public Invert ()
		{
			for (int i = 0; i < char.MaxValue; i++)
				Table [i] = (char)i;

			for (int i = 'a'; i <= 'z'; i++)
				Table [i] = (char)('z' - i + 'a');

			for (int i = 'A'; i <= 'Z'; i++)
				Table [i] = (char)('Z' - i + 'A')
		}

		public string InvertString (string s)
		{
			char[] arr = s.ToCharArray ();

			for (int i = 0; i < arr.Length; i++)
				arr [i] = Table [arr [i]];

			return new string (arr);
		}

		public static string InvertStringStatic (string s)
		{
			var inv = new Invert ();
			return inv.InvertString (s);
		}
	}
}

