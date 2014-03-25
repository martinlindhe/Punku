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
		// TODO recognize åäö etc
		if (c >= 'a' && c <= 'z')
			return false;

		return true;
	}

	public static bool IsLowerCase (this char c)
	{
		// TODO recognize ÅÄÖ etc
		if (c >= 'A' && c <= 'Z')
			return false;

		return true;
	}
}
