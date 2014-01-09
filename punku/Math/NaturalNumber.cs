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
		protected static byte[] Parse (
			string s, 
			uint numberBase = 10,
			string digitKeys = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
		)
		{
			// TODO add unit test that uses alternate digitKeys to decode something

			// creates a lookup table for char -> digit value
			byte[] digitValues = new byte[byte.MaxValue];
			for (int i = 0; i < digitKeys.Length; i++) {
				byte key = (byte)digitKeys [i];
				digitValues [key] = (byte)i;
			}

			if (s.Length < 1)
				throw new ArgumentOutOfRangeException ();

			if (numberBase < 2 || numberBase > digitKeys.Length)
				throw new ArgumentOutOfRangeException ();

			var res = new byte[s.Length];
			int idx = 0;

			foreach (char c in s) {

				byte val = digitValues [(byte)c];
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

