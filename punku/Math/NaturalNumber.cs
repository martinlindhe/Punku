/**
 * http://en.wikipedia.org/wiki/Natural_number
 * 
 * NOTE http://msdn.microsoft.com/en-us/library/system.numerics.biginteger%28v=vs.100%29.aspx
 * 		System.Numerics.BigInteger also exists
 */
using System;

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
			NumberBase = numberBase;
			Digits = Parse (s, numberBase);
		}

		/**
		 * Parses a number represented in a string
		 */
		protected static byte[] Parse (string s, uint numberBase = 10)
		{
			if (s.Length < 1)
				throw new FormatException ();

			if (numberBase > 10)
				throw new NotImplementedException ("TODO over base10");

			// TODO implement > base10 using a "key string" for each digit (0,1,2...)

			var res = new byte[s.Length];
			int idx = 0;

			foreach (char c in s) {

				byte val = (byte)(c - '0');
				if (val >= numberBase)
					throw new FormatException ("digit " + c + " is not in base " + numberBase);

				res [idx++] = val;
			}

			return res;
		}

		/**
		 * Converts number to another number base
		 */
		public NaturalNumber ToBase (uint digitBase)
		{
			throw new NotImplementedException ();
		}

		/**
		 * Converts a natural number to a decimal
		 */
		public decimal ToDecimal ()
		{
			decimal res = 0;

			foreach (byte b in Digits)
				res = (res * NumberBase) + b;

			return res;
		}
	}
}

