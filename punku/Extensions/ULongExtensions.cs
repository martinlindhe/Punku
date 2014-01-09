﻿using System;
using System.Text;

public static class ULongExtensions
{
	/**
	 * @return the number of digits in n
	 */
	public static uint CountDigits (this ulong n, uint numberBase = 10)
	{
		uint cnt = 1;

		while (n >= numberBase) {
			cnt++;
			n /= numberBase;
		}

		return cnt;
	}

	/**
	 * @return byte array of the separate digits in n (base 10)
	 */
	public static byte[] Digits (this ulong n, uint numberBase = 10)
	{
		// TODO this method should be in NaturalNumber class
		int count = (int)n.CountDigits (numberBase);
		byte[] digits = new byte[count];

		for (int i = count - 1; i >= 0; i--) {
			digits [i] = (byte)(n % numberBase);
			n /= numberBase;
		}

		return digits;
	}

	/**
	 * @return string representation of n written in base digitBase
	 */
	public static string ToBase (this ulong n, uint numberBase)
	{
		string digitKeys = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

		if (numberBase < 2 || numberBase > digitKeys.Length)
			throw new ArgumentException ("digitBase");

		var sb = new StringBuilder ();

		while (n > 0) {
			sb.Insert (0, digitKeys [(int)(n % numberBase)]);
			n /= numberBase;
		}

		return sb.ToString ();
	}

	/**
	 * @return true if n is a repeating digit (eg 4444, 999999)
	 * http://en.wikipedia.org/wiki/Repdigit
	 */
	public static bool IsRepdigit (this ulong n, uint numberBase = 10)
	{
		var digits = n.Digits (numberBase);

		if (digits.Length < 2)
			return false;

		byte last = 0;

		foreach (var x in digits) {
			if (last != 0 && x != last)
				return false;
			last = x;
		}

		return true;
	}

	/**
     * A pandigital number is an integer that in a given base has among
     * its significant digits each digit used in the base at least once.
     * For example, 1223334444555567890 is a pandigital number in base 10.
     */
	public static bool IsPandigitalNumber (this ulong n, uint numberBase = 10)
	{
		var digits = n.Digits (numberBase);
		var found = new byte[numberBase];

		foreach (var digit in digits)
			found [digit] = 1;

		foreach (var x in found) {
			if (x == 0)
				return false;
		} 

		return true;
	}

	/**
	 * @return true if n is a prime
	 */
	public static bool IsPrime (this ulong n)
	{
		for (ulong j = 2; j < n; j++)
			if (n % j == 0)
				return false;

		return true;
	}

	/**
	 * @return true if n is a even number
	 */
	public static bool IsEven (this ulong n)
	{
		if (n % 2 == 0)
			return true;

		return false;
	}

	/**
	 * @return true if n is a odd number
	 */
	public static bool IsOdd (this ulong n)
	{
		return !n.IsEven ();
	}
}


