/**
 * decodes substitution ciphers in various ways
 * caesar cipher  http://en.wikipedia.org/wiki/Caesar_cipher
 */

using System;

// TODO: create a substitution key, use it to encode / decode a string
namespace Punku.Strings
{
	public static class Rotate
	{
		/**
		 * Performs the ROT13 character rotation
		 */
		public static string Rot13 (string value)
		{
			int shift = 13;
			char[] array = value.ToCharArray ();
			for (int i = 0; i < array.Length; i++) {
				int number = (int)array [i];

				if (number >= 'a' && number <= 'z') {
					if (number > 'm') {
						number -= shift;
					} else {
						number += shift;
					}
				} else if (number >= 'A' && number <= 'Z') {
					if (number > 'M') {
						number -= shift;
					} else {
						number += shift;
					}
				}
				array [i] = (char)number;
			}
			return new string (array);
		}
	}
}

