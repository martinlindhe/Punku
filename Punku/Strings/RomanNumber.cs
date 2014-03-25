using System;
using System.Collections.Generic;
using System.Text;

// TODO: validate input string as "valid roman number"
namespace Punku.Strings
{
	public class RomanValue
	{
		public int value;
		public string letter;

		public RomanValue (int value, string letter)
		{
			this.value = value;
			this.letter = letter;
		}
	}

	public class RomanNumber
	{
		public static string DecimalToRoman (int value)
		{
			if (value > 4999)
				throw new Exception ("Cannot represent numbers larger than 4999");

			List<RomanValue> list = new List<RomanValue> ();

			list.Add (new RomanValue (1000, "M"));
			list.Add (new RomanValue (900, "CM"));
			list.Add (new RomanValue (500, "D"));
			list.Add (new RomanValue (400, "CD"));
			list.Add (new RomanValue (100, "C"));
			list.Add (new RomanValue (90, "XC"));
			list.Add (new RomanValue (50, "L"));
			list.Add (new RomanValue (40, "XL"));
			list.Add (new RomanValue (10, "X"));
			list.Add (new RomanValue (9, "IX"));
			list.Add (new RomanValue (5, "V"));
			list.Add (new RomanValue (4, "IV"));
			list.Add (new RomanValue (1, "I"));

			int n = value;
			string res = "";

			foreach (var roman in list) {
				// Determine the number of matches
				int matches = n / roman.value;

				// Store that many characters
				res += roman.letter.Repeat (matches);

				// Substract that from the number
				n = n % roman.value;
			}

			return res;
		}

		public static int RomanToDecimal (string value)
		{
			string tmp = value.ToUpper ();

			//			if (!self::isValid($s))
			//				throw new \Exception ('invalid roman number: '.$s);

			// Expand subtractive notation in Roman numerals
			tmp = tmp.Replace ("CM", "DCCCC");
			tmp = tmp.Replace ("CD", "CCCC");
			tmp = tmp.Replace ("XC", "LXXXX");
			tmp = tmp.Replace ("XL", "XXXX");
			tmp = tmp.Replace ("IX", "VIIII");
			tmp = tmp.Replace ("IV", "IIII");

			int val = 0;
			val += tmp.Count ('M') * 1000;
			val += tmp.Count ('D') * 500;
			val += tmp.Count ('C') * 100;
			val += tmp.Count ('L') * 50;
			val += tmp.Count ('X') * 10;
			val += tmp.Count ('V') * 5;
			val += tmp.Count ('I');

			return val;
		}
	}
}

