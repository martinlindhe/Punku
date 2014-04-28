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
}
