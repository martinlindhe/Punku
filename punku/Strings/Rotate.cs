/**
 * http://en.wikipedia.org/wiki/Caesar_cipher
 */

using System;

namespace Punku.Strings
{
	/**
	 * Transform english text to a rotated form (a = a + shift)
	 * also called a ceasar cipher
	 */
	public class Rotate
	{
		public char[] Table = new char[char.MaxValue];

		public Rotate (int shift)
		{
			for (int i = 0; i < char.MaxValue; i++)
				Table [i] = (char)i;

			for (int i = 'a'; i <= 'z'; i++) {
				if (i + shift <= 'z')
					Table [i] = (char)(i + shift);
				else
					Table [i] = (char)(i + shift - 'z' + 'a' - 1);
			}

			for (int i = 'A'; i <= 'Z'; i++) {
				if (i + shift <= 'Z')
					Table [i] = (char)(i + shift);
				else
					Table [i] = (char)(i + shift - 'Z' + 'A' - 1);
			}
		}

		public string RotateString (string s)
		{
			char[] arr = s.ToCharArray ();

			for (int i = 0; i < arr.Length; i++)
				arr [i] = Table [arr [i]];

			return new string (arr);
		}

		public static string RotateString (string s, int shift)
		{
			var x = new Rotate (shift);
			return x.RotateString (s);
		}

		/**
		 * Performs the ROT13 character rotation
		 */
		public static string Rot13 (string value)
		{
			return RotateString (value, 13);
		}
	}
}

