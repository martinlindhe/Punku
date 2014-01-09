/**
 * http://en.wikipedia.org/wiki/Natural_number
 * 
 * NOTE http://msdn.microsoft.com/en-us/library/system.numerics.biginteger%28v=vs.100%29.aspx
 * 		System.Numerics.BigInteger also exists
 */
using System;

// TODO unit tests for htis class
namespace Punku
{
	/**
	 * Can represent a very large number
	 */
	public class NaturalNumber
	{
		public byte[] Digits;
		protected uint NumberBase;

		public NaturalNumber (string s, uint numberBase = 10)
		{
			if (numberBase != 10)
				throw new NotImplementedException ("only handles base-10 input");

			NumberBase = numberBase;
			Digits = Parse (s);
		}

		/**
		 * Parses a base-10 number represented in a string
		 */
		protected static byte[] Parse (string s)
		{
			var res = new byte[s.Length];

			int idx = 0;

			foreach (char c in s) {
				if (c < '0' || c > '9')
					throw new FormatException ();

				res [idx++] = (byte)(c - '0');
			}

			return res;
		}

		/**
		 * Converts a natural number to a decimal
		 */
		public decimal ToDecimal ()
		{
			decimal res = 0;

			// XXXX TODO throw exception if number is too large
			foreach (byte b in Digits)
				res = (res * NumberBase) + b;

			return res;
		}
	}
}

