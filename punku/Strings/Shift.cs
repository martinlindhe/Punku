using System;

// TODO rework to first create a translation table, then apply it. see http://www.dotnetperls.com/translate
namespace Punku.Strings
{
	public static class Shift
	{
		public static string ShiftLetters (string s, int shift)
		{
			char[] array = s.ToCharArray ();

			for (int i = 0; i < array.Length; i++) {
				int number = (int)array [i];

				if (number >= 'a' && number <= 'z') {
					if (number + shift > 'z') {
						//number = 'a' + shift;

						// XXX ugly hack. drop when rewritten to use translation tbl
						if (number == 'y')
							number = 'a';
						if (number == 'z')
							number = 'b';
					} else
						number += shift;
				} else if (number >= 'A' && number <= 'Z') {
					//number += shift;
					throw new Exception ();
				}
				array [i] = (char)number;
			}
			return new string (array);
		}
	}
}

