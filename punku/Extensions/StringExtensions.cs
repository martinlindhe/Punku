using System;
using System.Text;
using Punku;

public static class StringExtensions
{
	/**
	 * repeat the string count times
	 */
	public static string Repeat (this string input, int count)
	{
		var builder = new StringBuilder ((input == null ? 0 : input.Length) * count);

		for (int i = 0; i < count; i++)
			builder.Append (input);

		return builder.ToString ();
	}

	/**
	 * return the number of times letter occurs
	 */
	public static int Count (this string input, char letter)
	{
		int count = 0;
		foreach (char c in input)
			if (c == letter)
				count++;

		return count;
	}

	/** 
	 * true if string only contains 0-9
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
	 * true if string only contains 0-9, a-z or A-Z
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
	 * true if string is a palindrome, like "racecar"
	 */
	public static bool IsPalindrome (this string input)
	{
		if (input.Length < 1)
			return false;

		char[] a1 = input.ToCharArray ();
		char[] a2 = input.ToCharArray ();
		Array.Reverse (a2);

		for (int i = 0; i < a1.Length; i++)
			if (a1 [i] != a2 [i])
				return false;

		return true;
	}
}
