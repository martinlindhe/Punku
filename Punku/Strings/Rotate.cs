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
	public class Rotate : StringTransformer
	{
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

		public static string Transform (string s, int shift)
		{
			var x = new Rotate (shift);
			return x.Transform (s);
		}

		/**
		 * Performs the ROT13 character rotation
		 */
		public static string Rot13 (string value)
		{
			return Transform (value, 13);
		}
	}
}
