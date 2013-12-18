/**
 * Converter between different numeral systems
 *
 * https://en.wikipedia.org/wiki/List_of_numeral_systems
 * 
 * http://en.wikipedia.org/wiki/Vigesimal (base-20, Mayans)
 * http://en.wikipedia.org/wiki/Sexagesimal (base-60, Babylonians)
 * http://en.wikipedia.org/wiki/Duodecimal (base-12, proposed by mathematicians)
 *
 * @author Martin Lindhe, 2010-2013 <martin@ubique.se>
 */
using System;

namespace Punku.Convert
{
	public class Base
	{
		public long Value;

		public Base (string s)
		{
			Value = ParseToInt64 (s);
		}

		public long ToDecimal ()
		{
			return this.Value;
		}

		public string ToHex ()
		{
			return "0x" + Value.ToString ("x");
		}

		public string ToOctal ()
		{
			return "0" + System.Convert.ToString (Value, 8);
		}

		public string ToBinary ()
		{
			return "b" + System.Convert.ToString (Value, 2);
		}

		public static long ParseToInt64 (string s)
		{
			long res;

			// hex (base 16)
			if (s.Substring (0, 2).ToLower () == "0x")
				return System.Convert.ToInt64 (s.Substring (2), 16);

			// binary (base 2)
			if (s.Substring (0, 1) == "b")
				return System.Convert.ToInt64 (s.Substring (1), 2);

			// octal (base 8)
			if (s.Substring (0, 1) == "0")
				return System.Convert.ToInt64 (s.Substring (1), 8);

			// decimal (base 10)
			if (Int64.TryParse (s, out res))
				return res;

			throw new Exception ("parse error");
		}

		public static string ToBase (int value, int toBase)
		{
			string AlphaCodes = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

			if (toBase < 2 || toBase > AlphaCodes.Length)
				throw new ArgumentException ("toBase");

			if (value < 0)
				throw new ArgumentException ("value");

			if (value == 0)
				return "0";

			string retVal = "";

			while (value > 0) {
				retVal = AlphaCodes [value % toBase] + retVal;
				value /= toBase;
			}

			return retVal;
		}
	}
}

