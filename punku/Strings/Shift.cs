using System;

// TODO: upper case!
// TODO: unit test for non-2-shifts
// FIXME: vad är skillnaden mellan Rot13? är det metoden...?
namespace Punku.Strings
{
	/**
	 * Transform english text to a shifted form (a = a + shift)
	 */
	public class Shift
	{
		public char[] Table = new char[char.MaxValue];

		public Shift (int shift)
		{
			for (int i = 0; i < char.MaxValue; i++)
				Table [i] = (char)i;

			for (int i = 'a'; i <= 'z'; i++) {
				if (i + shift <= 'z')
					Table [i] = (char)(i + shift);
				else
					Table [i] = (char)(i + shift - 'z' + 'a' - 1);
			}
		}

		public string ShiftString (string s)
		{
			char[] arr = s.ToCharArray ();

			for (int i = 0; i < arr.Length; i++)
				arr [i] = Table [arr [i]];

			return new string (arr);
		}

		public static string ShiftString (string s, int shift)
		{
			var x = new Shift (shift);
			return x.ShiftString (s);
		}
	}
}

