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

	/**
	 * Returns a Base64 encoded representation of the string, converted to UTF-8
	 */
	public static string ToBase64 (this string input)
	{
		return System.Text.ASCIIEncoding.UTF8.GetBytes (input).ToBase64 ();
	}

	/**
	 * Decodes a Base64 string to UTF-8
	 */
	public static string FromBase64 (this string input)
	{
		return System.Text.ASCIIEncoding.UTF8.GetString (input.FromBase64ToByteArray ());
	}

	/**
	 * Decodes a Base64 string to byte[] array
	 */
	public static byte[] FromBase64ToByteArray (this string input)
	{
		return System.Convert.FromBase64String (input);
	}
}
