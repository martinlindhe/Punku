using System;
using System.Text;

public static class ULongExtensions
{
	/**
	 * @return the number of digits in the number
	 */
	public static uint CountDigits (this ulong i, uint digitBase = 10)
	{
		uint cnt = 1;

		while (i >= digitBase) {
			cnt++;
			i /= digitBase;
		}

		return cnt;
	}

	/**
	 * @return byte array of the separate digits in the number (base 10)
	 */
	public static byte[] Digits (this ulong i, uint digitBase = 10)
	{
		int count = (int)i.CountDigits (digitBase);
		byte[] digits = new byte[count];

		for (int n = count - 1; n >= 0; n--) {
			digits [n] = (byte)(i % digitBase);
			i /= digitBase;
		}

		return digits;
	}

	/**
	 * @return string representation of i written in base digitBase
	 */
	public static string ToBase (this ulong i, uint digitBase)
	{
		string AlphaCodes = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

		if (digitBase < 2 || digitBase > AlphaCodes.Length)
			throw new ArgumentException ("digitBase");

		var sb = new StringBuilder ();

		while (i > 0) {
			sb.Insert (0, AlphaCodes [(int)(i % digitBase)]);
			i /= digitBase;
		}

		return sb.ToString ();
	}
}


