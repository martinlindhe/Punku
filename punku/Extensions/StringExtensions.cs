using System;
using System.Text;
using Punku;

public static class StringExtensions
{
	public static string Repeat (this string input, int count)
	{
		var builder = new StringBuilder ((input == null ? 0 : input.Length) * count);

		for (int i = 0; i < count; i++)
			builder.Append (input);

		return builder.ToString ();
	}

	public static int Count (this string input, char letter)
	{
		int count = 0;
		foreach (char c in input)
			if (c == letter)
				count++;

		return count;
	}

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
	 * Is string a palindrome, like "racecar" ?
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
