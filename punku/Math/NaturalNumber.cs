/**
 * http://en.wikipedia.org/wiki/Natural_number
 * 
 * NOTE http://msdn.microsoft.com/en-us/library/system.numerics.biginteger%28v=vs.100%29.aspx
 * 		System.Numerics.BigInteger also exists
 */
using System;
using System.Text;

namespace Punku
{
	/**
	 * Can represent a very large number
	 */
	public class NaturalNumber
	{
		public byte[] Digits;
		public uint NumberBase;

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

		public string ToString ()
		{
			var res = new StringBuilder ();

			foreach (byte b in Digits)
				res.Append ((char)(b + '0'));

			return res.ToString ();
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

			// NOTE no two numbers can be added that would increase the result more than one digit
			length++;

			NaturalNumber res = new NaturalNumber (10);
			res.Digits = new byte[length];

			//Console.WriteLine ("adding " + n1.ToDecimal () + " and " + n2.ToDecimal ());
			  
			long carry = 0;

			var c1 = n1.Digits.Length - 1;
			var c2 = n2.Digits.Length - 1;

			for (int i = length - 1; i >= 0; i--) {
				byte b1 = (c1 >= 0) ? n1.Digits [c1--] : (byte)0;
				byte b2 = (c2 >= 0) ? n2.Digits [c2--] : (byte)0;
				long sum = b1 + b2 + carry;

				//string s = b1 + " + " + b2 + " + carry " + carry + " = ";

				// NOTE assumes base 10
				carry = (sum % 100) / 10;
				if (sum > 9)
					sum = sum - 10;

				//Console.WriteLine (s + sum + ", carry = " + carry);

				res.Digits [i] = (byte)(sum & 0xFF);
			}

			return res;
		}
	}
}

