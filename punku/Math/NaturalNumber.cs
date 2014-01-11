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

		public NaturalNumber (uint numberBase = 10)
		{
			NumberBase = numberBase;
		}

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

		public override bool Equals (object o)
		{
			NaturalNumber n = (NaturalNumber)o;
			  
			if (Digits.Length != n.Digits.Length)
				return false;
			  
			for (int i = 0; i < Digits.Length; i++)
				if (Digits [i] != n.Digits [i])
					return false;

			return true;
		}

		/**
		 * Overloaded EQUAL (==) operator
		 */
		public static bool operator == (NaturalNumber n1, NaturalNumber n2)
		{
			return n1.Equals (n2);
		}

		/**
		 * Overloaded NOT EQUAL (!=) operator
		 */
		public static bool operator != (NaturalNumber n1, NaturalNumber n2)
		{
			return !(n1.Equals (n2));
		}

		/**
		 * Overloaded ADD (+) operator
		 */
		public static NaturalNumber operator + (NaturalNumber n1, NaturalNumber n2)
		{
			if (n1.NumberBase != 10 || n2.NumberBase != 10)
				throw new Exception ("TODO odd base");


			var length = (n1.Digits.Length > n2.Digits.Length) ? n1.Digits.Length : n2.Digits.Length;

			NaturalNumber res = new NaturalNumber (10);
			res.Digits = new byte[length];
			  
	
			long carry = 0;

			for (int i = 0; i < res.Digits.Length; i++) {
				byte b1 = (i < n1.Digits.Length) ? n1.Digits [i] : (byte)0;
				byte b2 = (i < n2.Digits.Length) ? n2.Digits [i] : (byte)0;
				long sum = b1 + b2 + carry;
				carry = sum >> 8;
				res.Digits [i] = (byte)(sum & 0xFF);
			}
			  
			if (carry != 0) {
				throw new Exception ("carry");
				// TODO verify this works?!?! it should allocate 1 extra byte at end of buffer
				// res.Digits [res.Digits.Length] = (byte)(carry);
				// res.Digits.Length++;
			}
			 
			// TODO hmmm.. it removes padding zeroes ...!??! can this go wrong?
			/*
			while (result.Digits.Length > 1 && result.Digits [result.Digits.Length - 1] == 0)
				result.Digits.Length--;
*/
			return res;
		}
	}
}

