using System;
using System.Text;

public static class CharExtensions
{
	/**
	 * Returns a 4-letter long hex value representation of a UTF-16 code unit
	 */
	public static string ToHexString (this char c)
	{
		int value = Convert.ToInt32 (c);
		return value.ToString ("x4");
	}

	public static bool IsUpperCase (this char c)
	{
		return Char.IsUpper (c);
	}

	public static bool IsLowerCase (this char c)
	{
		return Char.IsLower (c);
	}

	/**
	 * @return true if c is ASCII letter (a-z, A-Z)
	 */
	public static bool IsAsciiLetter (this char c)
	{
		if (c >= 'a' && c <= 'z')
			return true;

		if (c >= 'A' && c <= 'Z')
			return true;

		return false;
	}

	/**
	 * @return true if c is a ASCII digit (0-9)
	 */
	public static bool IsAsciiDigit (this char c)
	{
		if (c >= '0' && c <= '9')
			return true;

		return false;
	}

	/**
	 * @return true if c is a ASCII character letter or digit (a-z, A-Z, 0-9)
	 */
	public static bool IsAsciiLetterOrDigit (this char c)
	{
		if (IsAsciiLetter (c) || IsAsciiDigit (c))
			return true;

		return false;
	}
}
