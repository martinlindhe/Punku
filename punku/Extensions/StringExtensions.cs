﻿using System;
using System.Text;
using Punku;

public static class StringExtensions
{
	/**
	 * @return repeated string count times
	 */
	public static string Repeat (this string input, int count)
	{
		var builder = new StringBuilder (input.Length * count);

		for (int i = 0; i < count; i++)
			builder.Append (input);

		return builder.ToString ();
	}

	/**
	 * @return reversed string
	 */
	public static string Reverse (this string input)
	{
		if (input == null)
			return null;

		char[] array = input.ToCharArray ();
		Array.Reverse (array);
		return new String (array);
	}

	/**
	 * @return the number of times toCount occurs
	 */
	public static int Count (this string input, char toCount)
	{
		int count = 0;

		foreach (char c in input)
			if (c == toCount)
				count++;

		return count;
	}

	/** 
	 * @return true if string only contains letters 0-9
	 */
	public static bool IsNumbersOnly (this string input)
	{
		if (input == "")
			return false;

		foreach (char c in input)
			if (c < '0' || c > '9')
				return false;

		return true;
	}

	/** 
	 * @rerurn true if string only contains letters 0-9, a-z or A-Z
	 */
	public static bool IsAlphanumeric (this string input)
	{
		if (input == "")
			return false;

		foreach (char c in input)
			if ((c < '0' || c > '9') && (c < 'a' || c > 'z') && (c < 'A' || c > 'Z'))
				return false;
	
		return true;
	}

	/** 
	 * @return true if string is a palindrome, like "racecar"
	 */
	public static bool IsPalindrome (this string input)
	{
		if (input.Trim ().Length < 1)
			return false;

		char[] a1 = input.ToCharArray ();
		char[] a2 = input.ToCharArray ();
		Array.Reverse (a2);

		for (int i = 0; i < a1.Length; i++)
			if (a1 [i] != a2 [i])
				return false;

		return true;
	}

	/**
	 * Decodes a base-x encoded value
	 */
	public static ulong FromBase (this string input, uint numberBase)
	{
		ulong result = 0;

		if (numberBase > 10)
			throw new NotImplementedException ("TODO over base10");

		foreach (char c in input) {

			byte val = (byte)(c - '0');
			if (val >= numberBase)
				throw new FormatException ("digit " + c + " is not in base-" + numberBase);

			result = (result * numberBase) + val;
		}

		return result;
	}
}
