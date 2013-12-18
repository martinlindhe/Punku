/**
 * decodes substitution ciphers in various ways
 * caesar cipher  http://en.wikipedia.org/wiki/Caesar_cipher
 */

using System;

// TODO: create a substitution key, use it to encode / decode a string
namespace Punku.Strings
{
	public static class Rot13
	{
		/**
		 * Performs the ROT13 character rotation
		 */
		public static string Transform (string value)
		{
			char[] array = value.ToCharArray ();
			for (int i = 0; i < array.Length; i++) {
				int number = (int)array [i];

				if (number >= 'a' && number <= 'z') {
					if (number > 'm') {
						number -= 13;
					} else {
						number += 13;
					}
				} else if (number >= 'A' && number <= 'Z') {
					if (number > 'M') {
						number -= 13;
					} else {
						number += 13;
					}
				}
				array [i] = (char)number;
			}
			return new string (array);
		}
	}
}

